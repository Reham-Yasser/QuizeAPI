using QuizAPI.Dtos;
using QuizAPI.Entities;

namespace QuizAPI.Respositories
{
    public interface IQuestionRepository
    {
        Task<Question> Insert(QuestionCreateDto dtoModel);
        Task<IEnumerable<Question>> GetAll();
        Task<Question> Get(int id);
        Task<Answer> GetAnswerAsync(Question question);
    }
}
