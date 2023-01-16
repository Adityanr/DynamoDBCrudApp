using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;
using CRUDCloudDb.Interfaces;

namespace CRUDCloudDb.Services
{
    public class DynamoDbTableService: IDynamoDbService
    {
        #region Fields

        IAmazonDynamoDB _amazonDynamoDB;

        #endregion

        #region Constructor
        public DynamoDbTableService(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }

        #endregion

        #region Public Methods

        public async Task<CreateServiceResponse> Create(CreateServiceRequest createServiceRequest)
        {            
            var provisionedCapacityUnits = new ProvisionedThroughput
            {
                ReadCapacityUnits = createServiceRequest.ReadCapacityUnits,
                WriteCapacityUnits = createServiceRequest.WriteCapacityUnits
            };

            var result = await _amazonDynamoDB.CreateTableAsync(
                createServiceRequest.TableName,
                GenerateKeySchemaElements(createServiceRequest.PrimaryKey).Item1,
                GenerateKeySchemaElements(createServiceRequest.PrimaryKey).Item2,
                provisionedCapacityUnits);

            return new CreateServiceResponse
            {
                TableId = result.TableDescription.TableId,
                TableName = result.TableDescription.TableName,
                TableStatus = result.TableDescription.TableStatus,
                Status = result.HttpStatusCode
            };
        }

        public async Task<PutItemResponse> Put(PutEmployeeServiceRequest request)
        {
            return await _amazonDynamoDB.PutItemAsync(
                request.TableName,
                GetItemDictionary(request));
        }

        #endregion

        #region Private Methods

        private static Tuple<List<KeySchemaElement>, List<AttributeDefinition>> GenerateKeySchemaElements(
            string privateKey)
        {
            var schemaElements =  new List<KeySchemaElement>
            {
                new KeySchemaElement
                {
                    AttributeName = privateKey,
                    KeyType = KeyType.HASH
                }
            };

            var attributeDefinitions = new List<AttributeDefinition>
            {
                new AttributeDefinition
                {
                    AttributeName = privateKey,
                    AttributeType = ScalarAttributeType.N
                }
            };

            return new Tuple<List<KeySchemaElement>, List<AttributeDefinition>>(
                schemaElements, attributeDefinitions);
        }

        private static Dictionary<string, AttributeValue> GetItemDictionary(
            PutEmployeeServiceRequest serviceRequest)
        {
            return new Dictionary<string, AttributeValue>()
            {
                { "Id", new AttributeValue() { N = serviceRequest.Id.ToString() } },
                { "Name", new AttributeValue(serviceRequest.Name) },
                { "CreatedDate", new AttributeValue(serviceRequest.CreatedDate.ToString()) },
                { "Salary", new AttributeValue() { N = serviceRequest.Salary.ToString() } }
            };
        }

        #endregion
    }
}
