namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Post
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Навигационное свойство Пользователя
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        /// <summary>
        /// Id Еды
        /// </summary>
        public int FoodId { get; set; }

        /// <summary>
        /// Навигационное свойство Еды
        /// </summary>
        [ForeignKey("FoodId")]
        public virtual Food Food { get; set; }

        /// <summary>
        /// Дата поста
        /// </summary>
        public DateTime Date { get; set; }
    }
}