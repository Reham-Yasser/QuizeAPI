using Microsoft.EntityFrameworkCore;
using quizAPI.Entities;
using QuizAPI.Entities;

namespace QuizAPI.Data
{
    public class QuizAppContext : DbContext
    {
        public QuizAppContext(DbContextOptions<QuizAppContext> options) : base(options) { }

        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizQuestions> quizQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Score> Scores { get; set; }

       
    }
}
