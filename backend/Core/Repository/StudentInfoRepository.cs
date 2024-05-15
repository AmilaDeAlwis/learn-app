using backend.Core.Interfaces;
using backend.Core.Models;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace backend.Core.Repository
{
    public class StudentInfoRepository : IStudentInfoRepository
    {
        // Implementation of ICourseRepository methods
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public StudentInfoRepository(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("LearnApp", "Students");
        }

        public async Task<IEnumerable<StudentInfo>> GetAllAsync()
        {
            // Implementation to get all student information
            var query = _container.GetItemQueryIterator<StudentInfo>(new QueryDefinition("SELECT * FROM c"));
            List<StudentInfo> results = new List<StudentInfo>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
        public async Task<StudentInfo> GetByIdAsync(string id)
        {
            // Retrieve a studenti nfo by its ID
            try
            {
                ItemResponse<StudentInfo> response = await _container.ReadItemAsync<StudentInfo>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException($"A student with the ID '{id}' could not be found.");
            }
        }
        public async Task AddAsync(StudentInfo studentinfo)
        {
            await _container.CreateItemAsync(studentinfo, new PartitionKey(studentinfo.Id));
        }

        public async Task UpdateAsync(string id, StudentInfo studentinfo)
        {
            await _container.UpsertItemAsync(studentinfo, new PartitionKey(id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<StudentInfo>(id, new PartitionKey(id));
        }
    }
}
