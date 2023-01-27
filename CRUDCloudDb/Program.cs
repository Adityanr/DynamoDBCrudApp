using Amazon.DynamoDBv2;
using CRUDCloudDb.Interfaces;
using CRUDCloudDb.Mappers;
using CRUDCloudDb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDynamoDbService, DynamoDbTableService>();
builder.Services.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
builder.Services.AddScoped<ICreateControllerToServiceMapper, CreateControllerToServiceMapper>();
builder.Services.AddScoped<IPutControllerToServiceRequest, PutControllerToServiceRequestMapper>();
builder.Services.AddScoped<IDeleteControllerToServiceRequestMapper, DeleteControllerToServiceRequestMapper>();
builder.Services.AddScoped<IGetControllerToServiceRequestMapper, GetControllerToServiceRequestMapper>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
