using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;
using backend.Interfaces;
using backend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var cosmosDbEndpoint = configuration["CosmosDb:Endpoint"];
    var cosmosDbKey = configuration["CosmosDb:Key"];

    if (string.IsNullOrEmpty(cosmosDbEndpoint) || string.IsNullOrEmpty(cosmosDbKey))
    {
        throw new InvalidOperationException("Cosmos DB settings are not configured properly.");
    }
    return new CosmosClient(cosmosDbEndpoint, cosmosDbKey);
});

// Add services to the container.
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Create a Cosmos DB database and container on application startup
var cosmosClient = app.Services.GetRequiredService<CosmosClient>();
var databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync("LearnApp");
var database = databaseResponse.Database;

// Create 'Courses' container
var coursesContainerResponse = await database.CreateContainerIfNotExistsAsync("Courses", "/Id");
var coursesContainer = coursesContainerResponse.Container;

// Create 'StudentsInfo' container
var studentsInfoContainerResponse = await database.CreateContainerIfNotExistsAsync("Students", "/Id");
var studentsInfoContainer = studentsInfoContainerResponse.Container;

// Create 'CustomQuestions' container
var CustomQuestionContainerResponse = await database.CreateContainerIfNotExistsAsync("CustomQuestions", "/Id");
var CustomQuestionContainer = CustomQuestionContainerResponse.Container;

// Create 'AnswerOption' container
var AnswerOptionContainerResponse = await database.CreateContainerIfNotExistsAsync("AnswerOption", "/Id");
var AnswerOptionContainer = AnswerOptionContainerResponse.Container;

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
