using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheckApp.Models
{
    public class TestQuestion : ObservableObject
    {
        public TestQuestion(string description, List<TestAnswer> answers, string imagePath)
        {
            Description = description;
            Answers = answers;
            ImagePath = imagePath;
        }
        public string Description { get; }
        public string ImagePath { get; }
        public List<TestAnswer> Answers { get; }
        public TestAnswer GetCorrectAnswer()
        {
            return Answers.Single(e => e.IsCorrect == true);
        }
    }
}
