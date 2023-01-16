using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Interfaces
{
    public interface IDynamoDbService
    {
        Task<CreateServiceResponse> Create(CreateServiceRequest createServiceRequest);

        Task<PutItemResponse> Put(PutEmployeeServiceRequest request);
    }
}
