namespace Cuestionario.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Cuestionario.Models;

    public interface IQuestionRepository
    {
        Task<List<Question>> GetAsync();

        Task<Question> GetAsync(string id);

        Task CreateAsync(Question newQuestion);

        Task UpdateAsync(string id, Question updatedQuestion);

        Task RemoveAsync(string id);
    }
}
