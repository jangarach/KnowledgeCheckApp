using KnowledgeCheckApp.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Linq;
using System.Windows.Input;

namespace KnowledgeCheckApp.ViewModels
{
    public class UserDataViewModel : NavigationBaseViewModel
    {
        private readonly AppDbContext _appDbContext;

        private string _firstName;
        private string _lastName;

        public UserDataViewModel()
        {

        }

        public UserDataViewModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            FirstCommand = new RelayCommand(GoToHome);
            SecondCommand = new RelayCommand(OnGoToTest, CanExecuteLogin);
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (SetProperty(ref _firstName, value))
                    SecondCommand.NotifyCanExecuteChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (SetProperty(ref _lastName, value))
                    SecondCommand.NotifyCanExecuteChanged();
            }
        }

        private void OnGoToTest()
        {
            var user = new User
            {
                FirstName = FirstName,
                LastName = LastName
            };
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();

            var testViewModel = Ioc.Default.GetService<TestingViewModel>();
            testViewModel.User = user;
            GotToNext(testViewModel);
        }
        private bool CanExecuteLogin()
            => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }
}
