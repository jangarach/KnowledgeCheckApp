using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheckApp.Models
{
    public class TestAnswer : ObservableObject
    {
        public static event EventHandler AnswerPropertyChanged;
        private bool _isChecked;
        public TestAnswer(string text, bool isCorrect = false)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
        public string Text { get; }
        public bool IsCorrect { get; }
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (SetProperty(ref _isChecked, value))
                    AnswerPropertyChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}
