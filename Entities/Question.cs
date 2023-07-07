using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAPI.Entities
{
    public class Question : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string? Title { get; set; }
        [Required]
        public IEnumerable<Option>? Options { get; set; }
    }
}
