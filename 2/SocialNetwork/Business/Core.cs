using Data;
using Domain;
using System;
using System.Linq;

namespace Business
{
    public class Core : IDisposable
    {
        private readonly NetworkContext ctx;

        public Core()
        {
            try
            {
                ctx = new NetworkContext();
            }
            catch (Exception e)
            {
                throw new Exception($"Внутренняя ошибка сервера: {e.Message}");
            }
        }

        /// <summary>
        /// Получить еду
        /// </summary>
        /// <returns></returns>
        public IQueryable<Food> GetFoods()
        {
            return ctx.Foods;
        }

        public void Dispose()
        {
            try
            {
                ctx?.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception($"Внутренняя ошибка сервера: {e.Message}");
            }
        }

        /// <summary>
        /// Добавить пост
        /// </summary>
        /// <param name="user"></param>
        /// <param name="foodId"></param>
        public void AddPost(User user, int foodId)
        {
            ctx.Posts.Add(new Post()
            {
                UserId = user.Id,
                FoodId = foodId,
                Date = DateTime.Now
            });
            ctx.SaveChanges();
        }

        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public User AddUser(string name, string email)
        {
            var user = ctx.Users.Add(new User() { Name = name, Email = email });
            ctx.SaveChanges();
            return user;
        }

        /// <summary>
        /// Добавить блюдо
        /// </summary>
        /// <param name="name"></param>
        public Food AddFood(string name)
        {
            if (ctx.Foods.FirstOrDefault(f => f.Name == name) == null)
            {
                var food = ctx.Foods.Add(new Food() { Name = name });
                ctx.SaveChanges();
                return food;
            }
            else
            {
                throw new Exception("Ошибка добавления блюда! (Данное блюдо уже существует!)");
            }
        }

        /// <summary>
        /// Получить пользователя по мылу и имени
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUser(string name, string email)
        {
            return ctx.Users.FirstOrDefault(u => u.Name == name && u.Email == email);
        }

        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            return ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Получить последние 20 актуальных постов
        /// </summary>
        public IQueryable<Post> GetPosts()
        {
            return ctx.Posts.OrderByDescending(p => p.Date).Take(20);
        }

        /// <summary>
        /// Получить блюда
        /// </summary>
        /// <returns></returns>
        public IQueryable<Food> GetFood()
        {
            return ctx.Foods;
        }
    }
}
