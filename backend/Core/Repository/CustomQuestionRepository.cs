using backend.Core.Interfaces;
using backend.Core.Models;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace backend.Core.Repository
{
    public class CustomQuestionRepository : ICustomQuestionRepository
    {
        // Implementation of ICourseRepository methods
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CustomQuestionRepository(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("LearnApp", "CustomQuestions");
        }

        public async Task<IEnumerable<CustomQuestion>> GetAllAsync()
        {
            // Implementation to get all custom question
            var query = _container.GetItemQueryIterator<CustomQuestion>(new QueryDefinition("SELECT * FROM c"));
            List<CustomQuestion> results = new List<CustomQuestion>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
        public async Task<CustomQuestion> GetByIdAsync(string id)
        {
            // Retrieve a custom question by its ID
            try
            {
                ItemResponse<CustomQuestion> response = await _container.ReadItemAsync<CustomQuestion>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException($"could not be found.");
            }
        }
        public async Task AddAsync(CustomQuestion customquestion)
        {
            await _container.CreateItemAsync(customquestion, new PartitionKey(customquestion.Id));
        }

        public async Task UpdateAsync(string id, CustomQuestion customquestion)
        {
            await _container.UpsertItemAsync(customquestion, new PartitionKey(id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<CustomQuestion>(id, new PartitionKey(id));
        }
    }
}
