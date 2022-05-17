using KnowledgeCheckApp.Models;
using KnowledgeCheckApp.ViewModels;
using Microsoft.EntityFrameworkCore;
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
                .AddDbContext<AppDbContext>(option =>
                {
                    option.UseSqlite("Data Source = AppDatabase.db");
                })
                .AddSingleton<MainViewModel>()
                .AddScoped<HomeViewModel>()
                .AddTransient<UserDataViewModel>()
                .AddTransient<UsersScoreViewModel>()
                .AddTransient<TestingViewModel>()
                .AddTransient<ResultViewModel>()
                .BuildServiceProvider());
        }
    }
}
