using KnowledgeCheckApp.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace KnowledgeCheckApp.ViewModels;

public class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        CurrentViewModel = new HomeViewModel();
    }

    public MainViewModel(HomeViewModel homeViewModel)
    {
        CurrentViewModel = homeViewModel;
    }

    private NavigationBaseViewModel _currentViewModel;
    public NavigationBaseViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

}
