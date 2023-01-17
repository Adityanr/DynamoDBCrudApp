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

        public async Task<CreateTableResponse> Create(CreateTableRequest createTableRequest)
        {

            return await _amazonDynamoDB.CreateTableAsync(createTableRequest);
        }

        public async Task<PutItemResponse> Put(PutItemRequest request)
        {
            return await _amazonDynamoDB.PutItemAsync(request);
        }

        #endregion
    }
}
