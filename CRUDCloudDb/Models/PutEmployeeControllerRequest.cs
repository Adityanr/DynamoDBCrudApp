﻿using Amazon.DynamoDBv2.Model;

namespace CRUDCloudDb.Models
{
    public class PutEmployeeControllerRequest
    {
#nullable disable
        public string TableName { get; set; }
#nullable enable
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get => DateTime.UtcNow; }
        public double Salary { get; set; }
    }
}
