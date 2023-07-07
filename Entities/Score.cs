using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Entities
{
    public class Score : BaseEntity
    {
        public int TotalScore { get; set; }
        public int EarnedScore { get; set; }
       
    }
}
