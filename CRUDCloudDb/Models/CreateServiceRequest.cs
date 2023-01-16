using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace CRUDCloudDb.Models
{
    public class CreateServiceRequest
    {
#nullable disable
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
#nullable enable
        public int ReadCapacityUnits { get; set; }
        public int WriteCapacityUnits { get; set; }
    }
}
