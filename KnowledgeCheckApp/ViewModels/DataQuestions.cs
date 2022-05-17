using KnowledgeCheckApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheckApp.ViewModels
{
    public class DataQuestions
    {

        public static List<TestQuestion> GetTestQuestions()
        {
            var allQuestions = new List<TestQuestion>();
            //1
            var question = GetTestQuestion("По каким признакам судят о степени тяжести внутреннего кровотечения?", Path.GetFullPath("Assets/question1.jpg"));
            question.Answers.Add(GetTestAnswer("Состояние сознания, цвет кожных покровов, уровень артериального давления.", true));
            question.Answers.Add(GetTestAnswer("Показатели пульса, повышение температуры тела, судороги."));
            question.Answers.Add(GetTestAnswer("Резкая боль, появление припухлости, потеря сознания."));
            allQuestions.Add(question);
            //2
            question = GetTestQuestion("В каком положении эвакуируется пострадавший с вывихом нижней челюсти?", Path.GetFullPath("Assets/question2.jpg"));
            question.Answers.Add(GetTestAnswer("В положении лежа."));
            question.Answers.Add(GetTestAnswer("В положении сидя.", true));
            allQuestions.Add(question);
            //3
            question = GetTestQuestion("Как оказать помощь при ожоге кипятком?", Path.GetFullPath("Assets/question3.jpg"));
            question.Answers.Add(GetTestAnswer("Смазать обожженный участок мазью или лосьоном, наложить стерильную повязку."));
            question.Answers.Add(GetTestAnswer("Промывать обожженный участок холодной водой минут 10. Наложить стерильную повязку, дать болеутоляющие средства.",true));
            question.Answers.Add(GetTestAnswer("Обожженную поверхность присыпать пищевой содой, наложить стерильную повязку."));
            allQuestions.Add(question);
            //4
            question = GetTestQuestion("Первая медицинская помощь при обморожении?", Path.GetFullPath("Assets/question4.jpg"));
            question.Answers.Add(GetTestAnswer("Растереть пораженный участок жестким материалом или снегом."));
            question.Answers.Add(GetTestAnswer("Создать условия для общего согревания, наложить ватно-марлевую повязку на обмороженный участок, дать теплое питье.", true));
            question.Answers.Add(GetTestAnswer("Сделать легкий массаж, растереть пораженное место одеколоном."));
            allQuestions.Add(question);
            //5
            question = GetTestQuestion("Как оказать на месте происшествия первую помощь при простой  и неглубокой ране?", Path.GetFullPath("Assets/question5.jpg"));
            question.Answers.Add(GetTestAnswer("Наложить стерильную повязку."));
            question.Answers.Add(GetTestAnswer("Промыть рану лекарствами."));
            question.Answers.Add(GetTestAnswer("Обработать края раны йодом и наложить стерильную повязку.", true));
            allQuestions.Add(question);
            //6
            question = GetTestQuestion("Как начинать бинтование грудной клетки при ее ранении?", Path.GetFullPath("Assets/question6.jpg"));
            question.Answers.Add(GetTestAnswer("На выдохе с нижних отделов грудной клетки.", true));
            question.Answers.Add(GetTestAnswer("На вдохе с середины грудной клетки."));
            question.Answers.Add(GetTestAnswer("На выдохе от подмышечных ямок."));
            allQuestions.Add(question);
            //7
            question = GetTestQuestion("Какая повязка накладывается на нижнюю треть предплечья?", Path.GetFullPath("Assets/question7.jpg"));
            question.Answers.Add(GetTestAnswer("Крестообразная."));
            question.Answers.Add(GetTestAnswer("Спиралевидная."));
            question.Answers.Add(GetTestAnswer("Циркулярная.", true));
            allQuestions.Add(question);
            //8
            question = GetTestQuestion("Скелет человека состоит из следующих частей:", Path.GetFullPath("Assets/question8.jpg"));
            question.Answers.Add(GetTestAnswer("Голова, шея, грудная клетка, таз, конечности."));
            question.Answers.Add(GetTestAnswer("Череп, грудная клетка, позвоночник."));
            question.Answers.Add(GetTestAnswer("Череп, грудная клетка, позвоночник, конечности.", true));
            allQuestions.Add(question);
            //9
            question = GetTestQuestion("Что из содержимого автомобильной аптечки применяется для защиты рук человека, оказывающего помощь:", Path.GetFullPath("Assets/question9.jpg"));
            question.Answers.Add(GetTestAnswer("Салфетки."));
            question.Answers.Add(GetTestAnswer("Бинты."));
            question.Answers.Add(GetTestAnswer("Перчатки медицинские.", true));
            allQuestions.Add(question);
            //10
            question = GetTestQuestion("Алгоритм оказания помощи пострадавшему в ДТП в случае наличия у него артериального кровотечения:", Path.GetFullPath("Assets/question10.jpg"));
            question.Answers.Add(GetTestAnswer("Выставить знак аварийной остановки, надеть перчатки, опросить и осмотреть пострадавшего, уложить, приподнять конечность, пальцевое прижатие, наложить жгут выше места ранения, под жгут положить записку с временем наложения жгута, обработать рану, наложить повязку, вызвать службы помощи, инородные предметы не извлекать, напоить теплым питьем, контролировать состояние пострадавшего до приезда скорой помощи.", true));
            question.Answers.Add(GetTestAnswer("Немедленно наложить жгут выше места ранения, положить записку с временем наложения жгута, обработать рану, наложить повязку, укрыть одеялом, вызвать службу помощи."));
            question.Answers.Add(GetTestAnswer("Выставить знак аварийной остановки, надеть перчатки, опросить и осмотреть пострадавшего, уложить, приподнять конечность, пальцевое прижатие, извлечь из раны посторонние предметы, наложить жгут выше места ранения, под жгут положить записку с временем наложения жгута, обработать рану, наложить повязку, вызвать службы помощи, не поить теплым питьем, контролировать состояние пострадавшего до приезда скорой помощи."));
            allQuestions.Add(question);

            return allQuestions;
        }


        private static TestQuestion GetTestQuestion(string Description, string? imgPath = null, params TestAnswer[] values)
        {
            return new TestQuestion(Description, values?.ToList() ??new List<TestAnswer>(), imgPath);
        }

        private static TestAnswer GetTestAnswer(string Text, bool isCorrect = false)
        {
            return new TestAnswer(Text, isCorrect);
        }
    }
}
