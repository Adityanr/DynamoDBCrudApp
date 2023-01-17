using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Mappers
{
    public class CreateControllerToServiceMapper: ICreateControllerToServiceMapper
    {
        #region Public Methods

        public CreateTableRequest MapToCreateTableRequest(
            CreateControllerRequest controllerRequest)
        {
            return new CreateTableRequest
            {
                TableName = controllerRequest.TableName,
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = controllerRequest.ReadCapacityUnits,
                    WriteCapacityUnits = controllerRequest.WriteCapacityUnits,
                },
                KeySchema = GenerateKeySchemaElements(controllerRequest.PrimaryKey).Item1,
                AttributeDefinitions = GenerateKeySchemaElements(controllerRequest.PrimaryKey).Item2
            };
        }

        #endregion

        #region Private Methods

        private static Tuple<List<KeySchemaElement>, List<AttributeDefinition>> GenerateKeySchemaElements(
            string privateKey)
        {
            var schemaElements = new List<KeySchemaElement>
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

        #endregion
    }
}
