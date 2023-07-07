using QuizAPI.Entities;

namespace quizAPI.Entities
{
    public class QuizQuestions:BaseEntity
    {
        public Quiz quiz { get; set; }

        public Question question { get; set; }


    }
}
