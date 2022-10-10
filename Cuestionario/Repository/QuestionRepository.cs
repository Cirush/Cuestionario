using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cuestionario.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Cuestionario.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private IConfiguration _configuration;

        private string _conectionString;
        private string _databaseName;
        private string _collectionName;

        private readonly IMongoCollection<Question> _questionsCollection;

        public QuestionRepository()
        {
            _configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables().Build();
            _conectionString = _configuration.GetSection("QuestionaryDatabase:ConnectionString").Value;
            _databaseName = _configuration.GetSection("QuestionaryDatabase:DatabaseName").Value;
            _collectionName = _configuration.GetSection("QuestionaryDatabase:QuestionCollectionName").Value;

            var mongoClient = new MongoClient(_conectionString);

            var mongoDatabase = mongoClient.GetDatabase(_databaseName);

            _questionsCollection = mongoDatabase.GetCollection<Question>(_collectionName);
        }

        public async Task<List<Question>> GetAsync() =>
            await _questionsCollection.Find(_ => true).ToListAsync();

        public async Task<Question?> GetAsync(string id) =>
            await _questionsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Question newQuestion) =>
            await _questionsCollection.InsertOneAsync(newQuestion);

        public async Task UpdateAsync(string id, Question updatedQuestion) =>
            await _questionsCollection.ReplaceOneAsync(x => x.Id == id, updatedQuestion);

        public async Task RemoveAsync(string id) =>
            await _questionsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
