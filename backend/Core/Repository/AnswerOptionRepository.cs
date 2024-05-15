using backend.Core.Interfaces;
using backend.Core.Models;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace backend.Core.Repository
{
    public class AnswerOptionRepository : IAnswerOptionRepository
    {
        // Implementation of IAnswerOptionRepository methods
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public AnswerOptionRepository(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("LearnApp", "AnswerOption");
        }

        public async Task<IEnumerable<AnswerOption>> GetAllAsync()
        {
            // Implementation to get all answer option
            var query = _container.GetItemQueryIterator<AnswerOption>(new QueryDefinition("SELECT * FROM c"));
            List<AnswerOption> results = new List<AnswerOption>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
        public async Task<AnswerOption> GetByIdAsync(string id)
        {
            // Get an answer option by its ID
            try
            {
                ItemResponse<AnswerOption> response = await _container.ReadItemAsync<AnswerOption>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException($"Could not be found.");
            }
        }
        public async Task AddAsync(AnswerOption answerOption)
        {
            // Post an answer option
            await _container.CreateItemAsync(answerOption, new PartitionKey(answerOption.Id));
        }

        public async Task UpdateAsync(string id, AnswerOption answerOption)
        {
            // Update an answer option by its ID
            await _container.UpsertItemAsync(answerOption, new PartitionKey(id));
        }

        public async Task DeleteAsync(string id)
        {
            // Delete an answer option by its ID
            await _container.DeleteItemAsync<AnswerOption>(id, new PartitionKey(id));
        }
    }
}
