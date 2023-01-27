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

        public async Task<DeleteItemResponse> Delete(DeleteItemRequest deleteItemRequest)
        {
            return await _amazonDynamoDB.DeleteItemAsync(deleteItemRequest);
        }

        public async Task<GetItemResponse> Get(GetItemRequest getItemRequest)
        {
            return await _amazonDynamoDB.GetItemAsync(getItemRequest);
        }

        #endregion
    }
}
