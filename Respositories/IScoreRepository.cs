using QuizAPI.Dtos;
using QuizAPI.Entities;

namespace QuizAPI.Respositories
{
    public interface IScoreRepository
    {
        Task<Score> Insert(ScoreCreateDto dtoModel);
       // Task<IEnumerable<Score>> GetAllByQuiz(int quizId);
    }
}
