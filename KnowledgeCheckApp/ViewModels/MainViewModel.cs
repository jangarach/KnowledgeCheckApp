using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace KnowledgeCheckApp.ViewModels;

public class MainViewModel : ObservableObject
{
    public MainViewModel()
    {

    }

    string _testText = "Test";
    public string TestText
    {
        get => _testText;
        set => SetProperty(ref _testText, value);
    }
}
