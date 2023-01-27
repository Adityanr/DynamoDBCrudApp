using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Mappers
{
    public interface IGetControllerToServiceRequestMapper
    {
        GetItemRequest MapToGetItemRequestById(GetControllerRequestById request);
    }
}
