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
    public abstract class NavigationBaseViewModel : ObservableObject
    {
        private MainViewModel _mainViewModel;
        public RelayCommand FirstCommand { get; protected set; }
        public RelayCommand SecondCommand { get; protected set; }

        public NavigationBaseViewModel()
        {
        }

        protected void GoToHome()
        {
            var homeViewModel = Ioc.Default.GetService<HomeViewModel>();

            if (homeViewModel == null)
                throw new NullReferenceException(nameof(HomeViewModel));

            GotToNext(homeViewModel);
        }

        protected void GotToNext(NavigationBaseViewModel baseViewModel)
        {
            if (_mainViewModel == null)
                _mainViewModel = Ioc.Default.GetService<MainViewModel>();

            _mainViewModel.CurrentViewModel = baseViewModel;
        }
    }
}
