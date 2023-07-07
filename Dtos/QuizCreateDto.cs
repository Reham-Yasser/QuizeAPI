using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Dtos
{
    public class QuizCreateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public IEnumerable<int>? SelectedQuestionIds { get; set; }
    }
}
