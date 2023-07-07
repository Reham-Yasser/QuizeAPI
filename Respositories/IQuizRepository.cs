using quizAPI.Entities;
using QuizAPI.Dtos;
using QuizAPI.Entities;

namespace QuizAPI.Respositories
{
    public interface IQuizRepository
    {
        Task<Quiz> Insert(QuizCreateDto dtoModel);
        Task<IEnumerable<Quiz>> GetAll();
        Task<Quiz> Get(int id);
        Task<IEnumerable<QuizQuestions>> Getq_Qiz(int quizId);
       // Task<Quiz> GetQuizAsync(Quiz quiz);

       }
}
