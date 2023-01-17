using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Mappers
{
    public interface ICreateControllerToServiceMapper
    {
        CreateTableRequest MapToCreateTableRequest(CreateControllerRequest controllerRequest);
    }
}
