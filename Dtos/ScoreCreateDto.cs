using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Dtos
{
    public class ScoreCreateDto
    {
        [Required]
        public IEnumerable<QuestionAnswerDto>? AnsweredQuestions { get; set; }
     
    }
}
