using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Mappers
{
    public interface IPutControllerToServiceRequest
    {
        PutItemRequest MapToPutItemRequest(PutEmployeeControllerRequest putEmployeeControllerRequest);
    }
}
