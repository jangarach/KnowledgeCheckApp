using KnowledgeCheckApp.Models;
using KnowledgeCheckApp.Views;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;

namespace KnowledgeCheckApp.ViewModels
{
    public class ResultViewModel : NavigationBaseViewModel
    {
        public ResultViewModel()
        {
            FirstCommand = new RelayCommand(OnPrint);
            SecondCommand = new RelayCommand(GoToHome);
        }

        public UserScore UserScore { get; set; }
        public List<TestQuestion> AllTestQuestions { get; set; }
        private void OnPrint()
        {
            var _parent = new ResultReport(UserScore, AllTestQuestions);
            _parent.ShowDialog();
        }
    }
}
