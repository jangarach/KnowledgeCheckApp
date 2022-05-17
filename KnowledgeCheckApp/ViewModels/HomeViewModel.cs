using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheckApp.ViewModels
{
    public class HomeViewModel : NavigationBaseViewModel
    {
        public RelayCommand GoToResultsCommand { get; }
        public RelayCommand GoToTestCommand { get; }

        public HomeViewModel()
        {
            GoToResultsCommand = new RelayCommand(OnGoToResults);
            GoToTestCommand = new RelayCommand(OnGoToTest);
        }

        private void OnGoToResults()
        {
            var usersScoreViewModel = Ioc.Default.GetService<UsersScoreViewModel>();
            GotToNext(usersScoreViewModel);
        }

        private void OnGoToTest()
        {
            var userDataViewModel = Ioc.Default.GetService<UserDataViewModel>();
            GotToNext(userDataViewModel);
        }
    }
}
