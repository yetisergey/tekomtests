namespace Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Мыло
        /// </summary>
        [MaxLength(1024), Required]
        public string Email { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [MaxLength(1024), Required]
        public string Name { get; set; }

        /// <summary>
        /// Посты
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }
    }
}