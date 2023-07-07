﻿using QuizAPI.Entities;

namespace QuizAPI.Dtos
{
    public class QuestionCreateDto
    {
        public string QuestionTitle { get; set; }
        public int QuestionTimeLimit { get; set; }
        public IEnumerable<string> Options { get; set; }
        public string Answer { get; set; }
    }
}
