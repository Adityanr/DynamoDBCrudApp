using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Mappers
{
    public interface IDeleteControllerToServiceRequestMapper
    {
        DeleteItemRequest MapToDeleteItemRequestById(DeleteControllerRequestById request);
    }
}
