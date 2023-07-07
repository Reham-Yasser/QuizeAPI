using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using QuizAPI.Data;
using QuizAPI.Dtos;
using QuizAPI.Entities;
using QuizAPI.Utils;

namespace QuizAPI.Respositories
{
    public class ScoreRepository : IScoreRepository
    {
        private QuizAppContext _dbContext;
        private IQuestionRepository _questionRepository;
        private IQuizRepository _quizRepository;
        public ScoreRepository(QuizAppContext dbContext, IQuestionRepository questionRepository, IQuizRepository quizRepository)
        { 
            _dbContext = dbContext;
            _questionRepository = questionRepository;
            _quizRepository = quizRepository;
        }

        public async Task<Score> Insert(ScoreCreateDto dtoModel)
        {
            int totalScore = dtoModel.AnsweredQuestions.Count()*2;
            int earnedScore = await CalculateEarnedScore(dtoModel);
           
            var score = new Score
            {
                TotalScore = totalScore,
                EarnedScore = earnedScore,
                  };

            var valueTask = _dbContext.Scores.Add(score);
            await _dbContext.SaveChangesAsync();
            return valueTask.Entity;
        }

        private async Task<int> CalculateEarnedScore(ScoreCreateDto dtoModel)
        {
            int totalScore = 0;
            foreach (var item in dtoModel.AnsweredQuestions)
            {
                var question = await _questionRepository.Get(item.QuestionId);
                var originalAnswer = await _questionRepository.GetAnswerAsync(question);
                if (originalAnswer.Option.Id == item.AnswerId)
                {
                    totalScore++;
                }
            }

            return totalScore *2;
        }

       
    }
}
