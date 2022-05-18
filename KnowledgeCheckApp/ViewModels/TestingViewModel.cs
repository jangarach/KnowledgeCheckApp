using KnowledgeCheckApp.Models;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Threading;

namespace KnowledgeCheckApp.ViewModels
{
    public class TestingViewModel : NavigationBaseViewModel
    {
        private readonly TimeOnly TestTimeLimit = new TimeOnly(0, 3, 30);
        private DateTime StartTestTime;

        private int _currentIndex;
        private string _nextBtnContent = "Следующий";

        private TestQuestion _testQuestion;
        private List<TestQuestion> _allTestQuestions;

        private readonly AppDbContext _appDbContext;


        public TestingViewModel()
        {
            _allTestQuestions = DataQuestions.GetTestQuestions();
            Question = _allTestQuestions[_currentIndex];
            FirstCommand = new RelayCommand(OnPrevQuestion, CanExecutePrevQuestion);
            SecondCommand = new RelayCommand(OnNextQuestion, CanExecuteNextQuestion);
            TestAnswer.AnswerPropertyChanged += TestAnswer_AnswerPropertyChanged;
        }

        public TestingViewModel(AppDbContext appDbContext)
            :this()
        {
            _appDbContext = appDbContext;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            StartTestTime = DateTime.Now;
        }

        private void TestAnswer_AnswerPropertyChanged(object? sender, System.EventArgs e)
        {
            if (IsLastQuestion)
                SecondCommand.NotifyCanExecuteChanged();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            TestTimeCounter = TimeOnly.FromTimeSpan(DateTime.Now - StartTestTime);
            IsEndedTestTime = TestTimeCounter >= TestTimeLimit;
        }

        public string QuestionNumber => $"Вопрос {_currentIndex + 1} из {_allTestQuestions.Count}";

        private TimeOnly _testTimeCounter;
        public TimeOnly TestTimeCounter
        {
            get => _testTimeCounter;
            set => SetProperty(ref _testTimeCounter, value);
        }

        private bool _isEndedTestTime;
        public bool IsEndedTestTime
        {
            get => _isEndedTestTime;
            set => SetProperty(ref _isEndedTestTime, value);
        }

        public User User { get; set; }

        public TestQuestion Question
        {
            get => _testQuestion;
            set => SetProperty(ref _testQuestion, value);
        }

        public string NextBtnContent
        {
            get => _nextBtnContent;
            set => SetProperty(ref _nextBtnContent, value);
        }

        private void OnNextQuestion()
        {
            if (IsLastQuestion)
            {
                var userScore = new UserScore()
                {
                    UserId = User.Id,
                    DateStamp = DateTime.Now,
                    UsedTime = TimeOnly.FromTimeSpan(DateTime.Now - StartTestTime),
                    QuestionsCount = _allTestQuestions.Count,
                    CountOfCorrectAnswers = _allTestQuestions.Where(e => e.Answers.Exists(a => a.IsChecked && a.IsCorrect)).Count()
                };
                _appDbContext.Add(userScore);
                _appDbContext.SaveChanges();

                var resulViewModel = Ioc.Default.GetService<ResultViewModel>();
                resulViewModel.UserScore = userScore;
                resulViewModel.AllTestQuestions = _allTestQuestions;
                resulViewModel.IsOutOfTimeLimit = TestTimeCounter >= TestTimeLimit;

                GotToNext(resulViewModel);
            }
            else
            {
                _currentIndex += 1;
                UpdateQuestion();
            }
        }

        private void OnPrevQuestion()
        {
            _currentIndex -= 1;
            UpdateQuestion();
        }

        private bool CanExecuteNextQuestion()
        {
            if (IsLastQuestion)
            {
                var q = _allTestQuestions.FirstOrDefault(e => e.Answers.Exists(a => a.IsChecked) == false);
                return q == null ? true : false;
            }
            return true;
        }

        private bool IsLastQuestion => _currentIndex + 1 == _allTestQuestions.Count;

        private bool CanExecutePrevQuestion() => (_currentIndex - 1) >= 0 ;

        private void UpdateQuestion()
        {
            Question = _allTestQuestions[_currentIndex];
            FirstCommand.NotifyCanExecuteChanged();
            SecondCommand.NotifyCanExecuteChanged();
            OnPropertyChanged(nameof(QuestionNumber));

            if (_currentIndex == _allTestQuestions.Count - 1)
            {
                NextBtnContent = "Завершить";
            }
            else
            {
                NextBtnContent = "Следующий";
            }
        }
    }
}
