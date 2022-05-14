using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace KnowledgeCheckApp.ViewModels
{
    /// <summary>
    /// Дополнительная абстракция для получения ViewModel из View
    /// </summary>
    public class ViewModelLocator
    {
        public MainViewModel? MainViewModel => Ioc.Default.GetService<MainViewModel>();
        public LoginViewModel? LoginViewModel => Ioc.Default.GetService<LoginViewModel>();
    }
}
