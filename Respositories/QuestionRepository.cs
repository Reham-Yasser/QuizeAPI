using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.Dtos;
using QuizAPI.Entities;

namespace QuizAPI.Respositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizAppContext _dbContext;
        public QuestionRepository(QuizAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Question> Get(int id)
        {
            return await _dbContext.Questions.FindAsync(id);
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _dbContext.Questions.Include(question => question.Options).ToListAsync();
        }

        public async Task<Question> Insert(QuestionCreateDto dtoModel)
        {
            var options = new List<Option>();
            foreach(string value in dtoModel.Options)
            {
                options.Add(new Option { Name = value });
            }

            var question = new Question
            {
                Title = dtoModel.QuestionTitle,
                Options = options
            };

            var answer = new Answer
            {
                Question = question,
                Option = question.Options.FirstOrDefault(item => item.Name == dtoModel.Answer)
            };

            _dbContext.Answers.Add(answer);

            var valueTask = _dbContext.Questions.Add(question);
            await _dbContext.SaveChangesAsync();
            return valueTask.Entity;
        }

        public async Task<Answer> GetAnswerAsync(Question question)
        {
            return await _dbContext.Answers.Include(Op => Op.Option)
                .Where(Op => Op.Question.Id == question.Id).FirstOrDefaultAsync();
        }
    }
}
