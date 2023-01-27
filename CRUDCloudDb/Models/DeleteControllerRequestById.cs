using Amazon.DynamoDBv2.Model;

namespace CRUDCloudDb.Models
{
    public class DeleteControllerRequestById
    {
#nullable disable
        public string TableName { get; set; }
#nullable enable
        public int Id { get; set; }
    }
}
