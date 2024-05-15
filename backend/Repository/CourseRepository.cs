using backend.Interfaces;
using backend.Models;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace backend.Repository
{
    public class CourseRepository : ICourseRepository
    {
        // Implementation of ICourseRepository methods
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CourseRepository(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("LearnApp", "Courses");
        }
        
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            // Implementation to get all courses
            var query = _container.GetItemQueryIterator<Course>(new QueryDefinition("SELECT * FROM c"));
            List<Course> results = new List<Course>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
        public async Task<Course> GetByIdAsync(string id)
        {
            // Retrieve a course by its ID
            try
            {
                ItemResponse<Course> response = await _container.ReadItemAsync<Course>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException($"A course with the ID '{id}' could not be found.");
            }
        }
        public async Task AddAsync(Course course)
        {
            await _container.CreateItemAsync(course, new PartitionKey(course.Id));
        }

        public async Task UpdateAsync(string id, Course course)
        {
            await _container.UpsertItemAsync(course, new PartitionKey(id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Course>(id, new PartitionKey(id));
        }
    }

}
