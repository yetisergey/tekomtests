namespace Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Food
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(1024), Required]
        public string Name { get; set; }

        /// <summary>
        /// Посты
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }

        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}