using KnowledgeCheckApp.Models;
using KnowledgeCheckApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace KnowledgeCheckApp.ViewModels
{
    public class UsersScoreViewModel : NavigationBaseViewModel
    {
        private readonly AppDbContext _appDbContext;
        public ObservableCollection<UserScore> UsersScore { get; } = new ObservableCollection<UserScore>();
        public RelayCommand DeleteCommand { get; }

        public UsersScoreViewModel()
        {
            UsersScore = new ObservableCollection<UserScore>()
            {
                new UserScore()
                {
                    User = new User
                    {
                        FirstName = "Михаил",
                        LastName = "Попов"
                    },
                    QuestionsCount = 10,
                    CountOfCorrectAnswers = 8,
                    DateStamp = DateTime.Now,
                    UsedTime = new TimeOnly(0,5,2)
                },

                new UserScore()
                {
                    User = new User
                    {
                        FirstName = "Михаил",
                        LastName = "Попов"
                    },
                    QuestionsCount = 10,
                    CountOfCorrectAnswers = 8,
                    DateStamp = DateTime.Now,
                    UsedTime = new TimeOnly(0,5,2)
                },

                new UserScore()
                {
                    User = new User
                    {
                        FirstName = "Михаил",
                        LastName = "Попов"
                    },
                    QuestionsCount = 10,
                    CountOfCorrectAnswers = 8,
                    DateStamp = DateTime.Now,
                    UsedTime = new TimeOnly(0,5,2)
                }
            };
        }

        public UsersScoreViewModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            FirstCommand = new RelayCommand(GoToHome);
            SecondCommand = new RelayCommand(OnPrint, () => UsersScore?.Count > 0);
            DeleteCommand = new RelayCommand(OnDelete, () => UsersScore?.Count > 0);
            UpdateScoreViewList();
        }

        private void UpdateScoreViewList()
        {
            UsersScore.Clear();

            var listUsersScore = _appDbContext.UsersScore.Include(e => e.User).ToList();
            if (listUsersScore != null && listUsersScore.Count > 0)
            {
                foreach (var userScore in listUsersScore)
                {
                    UsersScore.Add(userScore);
                }
            }
            SecondCommand.NotifyCanExecuteChanged();
            DeleteCommand.NotifyCanExecuteChanged();
        }

        private void OnDelete()
        {
            foreach (var userScore in _appDbContext.UsersScore)
            {
                _appDbContext.UsersScore.Remove(userScore);
            }

            foreach (var user in _appDbContext.Users)
            {
                _appDbContext.Users.Remove(user);
            }

            _appDbContext.SaveChanges();
            UpdateScoreViewList();
        }

        private void OnPrint()
        {
            ResultAllReport report = new ResultAllReport();
            report.lstAllResult.ItemsSource = UsersScore;
            //report.fixedDoc.DocumentPaginator.PageSize = new Size(96 * 8.5, 96 * 11);

            //var tee = new List<UserScore>();

            //PrintDocument pd = new PrintDocument();
            //DocumentPaginator paginator = new BookPaginator(doc.DocumentPaginator, doc.DocumentPaginator.PageSize);
            //pd.Print(paginator, "Books");

            //for (int i = 0; i< 10; i++)
            //{
            //    foreach (var t in UsersScore)
            //    {
            //        tee.Add(t);
            //    }
            //}
            //report.lstAllResult.ItemsSource = tee;

            report.ShowDialog();
        }
    }
}
