using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Interfaces;
using CRUDCloudDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCloudDb.Controllers
{
    public class DynamoDbController : BaseApiController
    {
        private readonly ILogger<DynamoDbController> _logger;

        private readonly IDynamoDbService _dynamoDbService;

        #region Constructor

        public DynamoDbController(ILogger<DynamoDbController> logger,
            IDynamoDbService dynamoDbService)
        {
            _logger = logger;
            _dynamoDbService = dynamoDbService;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        public async Task<CreateControllerResponse> Create(
            CreateControllerRequest createControllerRequest)
        {
            var result = await _dynamoDbService.Create(new CreateServiceRequest
            {
                TableName = createControllerRequest.TableName,
                PrimaryKey = createControllerRequest.PrimaryKey,
                ReadCapacityUnits = createControllerRequest.ReadCapacityUnits,
                WriteCapacityUnits = createControllerRequest.WriteCapacityUnits
            });

            return new CreateControllerResponse
            {
                TableId = result.TableId,
                TableName = result.TableName,
                TableStatus = result.TableStatus,
                Status = result.Status
            };
        }

        [HttpPost("put")]
        public async Task<PutItemResponse> Put(
            PutEmployeeServiceRequest putEmployeeControllerRequest)
        {
            return await _dynamoDbService.Put(new PutEmployeeServiceRequest
            {
                TableName = putEmployeeControllerRequest.TableName,
                Id = putEmployeeControllerRequest.Id,
                Name = putEmployeeControllerRequest.Name,
                Salary = putEmployeeControllerRequest.Salary
            });
        }

        #endregion
    }
}