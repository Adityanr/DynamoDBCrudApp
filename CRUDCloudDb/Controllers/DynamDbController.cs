using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Interfaces;
using CRUDCloudDb.Mappers;
using CRUDCloudDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCloudDb.Controllers
{
    public class DynamoDbController : BaseApiController
    {
        private readonly ILogger<DynamoDbController> _logger;

        private readonly IDynamoDbService _dynamoDbService;

        private readonly ICreateControllerToServiceMapper _createControllerToServiceMapper;

        private readonly IPutControllerToServiceRequest _putControllerToServiceRequest;

        private readonly IDeleteControllerToServiceRequestMapper _deleteControllerToServiceRequestMapper;

        private readonly IGetControllerToServiceRequestMapper _getControllerToServiceRequestMapper;

        #region Constructor

        public DynamoDbController(ILogger<DynamoDbController> logger,
            IDynamoDbService dynamoDbService, ICreateControllerToServiceMapper createControllerToServiceMapper,
            IPutControllerToServiceRequest putControllerToServiceRequest,
            IDeleteControllerToServiceRequestMapper deleteControllerToServiceRequestMapper,
            IGetControllerToServiceRequestMapper getControllerToServiceRequestMapper)
        {
            _logger = logger;
            _dynamoDbService = dynamoDbService;
            _createControllerToServiceMapper = createControllerToServiceMapper;
            _putControllerToServiceRequest = putControllerToServiceRequest;
            _deleteControllerToServiceRequestMapper = deleteControllerToServiceRequestMapper;
            _getControllerToServiceRequestMapper = getControllerToServiceRequestMapper;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        public async Task<CreateTableResponse> Create(
            CreateControllerRequest createControllerRequest)
        {
            return await _dynamoDbService.Create(
                _createControllerToServiceMapper.MapToCreateTableRequest(createControllerRequest));
        }

        [HttpPost("put")]
        public async Task<PutItemResponse> Put(
            PutEmployeeControllerRequest putEmployeeControllerRequest)
        {
            return await _dynamoDbService.Put(_putControllerToServiceRequest.MapToPutItemRequest(
                putEmployeeControllerRequest));
        }

        [HttpPost("delete")]
        public async Task<DeleteItemResponse> DeleteById(
            DeleteControllerRequestById request)
        {
            return await _dynamoDbService
                .Delete(_deleteControllerToServiceRequestMapper
                .MapToDeleteItemRequestById(request));
        }

        [HttpPost("get")]
        public async Task<GetItemResponse> GetItemById(
            GetControllerRequestById request)
        {
            return await _dynamoDbService
                .Get(_getControllerToServiceRequestMapper
                .MapToGetItemRequestById(request));
        }

        #endregion
    }
}