using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Interfaces
{
    public interface IDynamoDbService
    {
        Task<CreateTableResponse> Create(CreateTableRequest createTableRequest);
        Task<PutItemResponse> Put(PutItemRequest request);
        Task<DeleteItemResponse> Delete(DeleteItemRequest request);
        Task<GetItemResponse> Get(GetItemRequest getItemRequest);
    }
}
