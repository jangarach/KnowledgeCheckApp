using KnowledgeCheckApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KnowledgeCheckApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ResultReport.xaml
    /// </summary>
    public partial class ResultReport : Window
    {
        public ResultReport(UserScore userScore, List<TestQuestion> testQuestions)
        {
            InitializeComponent();

            txtFirstName.Text = userScore.User.FirstName;
            txtLastName.Text = userScore.User.LastName;

            var resTest = new List<ResultTest>
            {
                new ResultTest
                {
                    DateStamp = userScore.DateStamp,
                    PointsScored = userScore.CountOfCorrectAnswers,
                    Result = userScore.CountOfCorrectAnswers > 7 ? "Пройдено" : "Не пройдено"
                }
            };

            lstResult.ItemsSource = resTest;

            var resAllTest = new List<ResultAllTest>();

            int i = 0;
            foreach(var t in testQuestions)
            {
                var isCorrect = t.Answers.Exists(e => e.IsChecked && e.IsCorrect);
                resAllTest.Add(new ResultAllTest
                {
                    Number = ++i,
                    Question = t.Description,
                    PointsScored = isCorrect ? 1 : 0,
                    Weight = 1,
                    IsCorrect = isCorrect
                });
            }
            lstAllResult.ItemsSource = resAllTest;
        }
    }

    public class ResultTest
    {
        public DateTime DateStamp { get; set; }
        public int PointsScored { get; set; }
        public string Result { get; set; }
    }

    public class ResultAllTest
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public int PointsScored { get; set; }
        public int Weight { get; set; }
        public bool IsCorrect { get; set; }
    }
}
