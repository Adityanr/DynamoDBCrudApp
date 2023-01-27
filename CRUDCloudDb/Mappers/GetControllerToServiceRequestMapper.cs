using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Mappers
{
    public class GetControllerToServiceRequestMapper: IGetControllerToServiceRequestMapper
    {
        #region Public Methods

        public GetItemRequest MapToGetItemRequestById(GetControllerRequestById request)
        {
            return new GetItemRequest
            {
                TableName = request.TableName,
                Key = new Dictionary<string, AttributeValue>() 
                { { "Id", new AttributeValue() { N = request.Id.ToString() } } }
            };
        }

        #endregion
    }
}
