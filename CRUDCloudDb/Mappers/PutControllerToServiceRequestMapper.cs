using Amazon.DynamoDBv2.Model;
using CRUDCloudDb.Models;

namespace CRUDCloudDb.Mappers
{
    public class PutControllerToServiceRequestMapper : IPutControllerToServiceRequest
    {
        #region Public Methods

        public PutItemRequest MapToPutItemRequest(PutEmployeeControllerRequest putEmployeeControllerRequest)
        {
            return new PutItemRequest
            {
                TableName = putEmployeeControllerRequest.TableName,
                Item = GetItemDictionary(putEmployeeControllerRequest),
            };
        }

        #endregion

        #region Private Methods

        private static Dictionary<string, AttributeValue> GetItemDictionary(
            PutEmployeeControllerRequest serviceRequest)
        {
            return new Dictionary<string, AttributeValue>()
            {
                { "Id", new AttributeValue() { N = serviceRequest.Id.ToString() } },
                { "Name", new AttributeValue(serviceRequest.Name) },
                { "CreatedDate", new AttributeValue(serviceRequest.CreatedDate.ToString()) },
                { "Salary", new AttributeValue() { N = serviceRequest.Salary.ToString() } }
            };
        }

        #endregion
    }
}
