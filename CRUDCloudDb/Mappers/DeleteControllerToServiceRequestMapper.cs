using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CRUDCloudDb.Mappers
{
    public class DeleteControllerToServiceRequestMapper: IDeleteControllerToServiceRequestMapper
    {
        #region Public Methods

        public DeleteItemRequest MapToDeleteItemRequestById(DeleteControllerRequestById request)
        {
            return new DeleteItemRequest
            {
                TableName = request.TableName,
                Key = new Dictionary<string, AttributeValue>() 
                { { "Id", new AttributeValue() { N = request.Id.ToString() } } }
            };
        }

        #endregion
    }
}
