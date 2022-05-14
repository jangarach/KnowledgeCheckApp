using KnowledgeCheckApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Windows;

namespace KnowledgeCheckApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddScoped<MainViewModel>()
                .AddScoped<LoginViewModel>()
                .BuildServiceProvider());
        }
    }
}
