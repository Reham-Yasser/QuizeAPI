using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Entities
{
    public class Quiz : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public IList<Question>? Questions { get; set; }
    }
}
