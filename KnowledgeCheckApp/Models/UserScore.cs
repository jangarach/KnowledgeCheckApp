using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeCheckApp.Models
{
    /// <summary>
    /// DTO для получения результатов пользователя
    /// </summary>
    public class UserScore
    {
        /// <summary>
        /// ИД законченного теста
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// ИД пользователя, который проходил тест
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// Дата прохождения теста
        /// </summary>
        public DateTime DateStamp { get; set; }

        /// <summary>
        /// Затрачено времени для прохождения теста
        /// </summary>
        public TimeOnly UsedTime { get; set; }

        /// <summary>
        /// Количество вопросов
        /// </summary>
        public int QuestionsCount { get; set; }

        /// <summary>
        /// Количество правильных ответов
        /// </summary>
        public int CountOfCorrectAnswers { get; set; }

    }
}
