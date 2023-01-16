using Amazon.DynamoDBv2;
using System.Net;

namespace CRUDCloudDb.Models
{
    public class CreateControllerResponse
    {
        public string? TableId { get; set; }
        public string? TableName { get; set; }
#nullable disable
        public TableStatus TableStatus { get; set; }
#nullable enable
        public HttpStatusCode Status { get; set; }
    }
}
