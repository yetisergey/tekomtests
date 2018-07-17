namespace SocialNetwork.Controllers
{
    using Business;
    using System;
    using System.Linq;
    using System.Web.Http;
    [Authorize]
    public class InfoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                using (var core = new Core())
                {
                    var user = core.GetUser(int.Parse(User.Identity.Name));
                    var lastFood = user.Posts.OrderByDescending(u => u.Date).First().Food;
                    var countPostLastFoodToday = lastFood.Posts.Where(p => p.Date.Date == DateTime.Now.Date).Count();
                    var countPostLastFoodForUser = lastFood.Posts.Where(p => p.FoodId == lastFood.Id).Count();
                    return Ok(new
                    {
                        History = core.GetPosts().ToList().Select(p => $"{p.Date.ToString("HH:mm:ss dd/MM/yyyy")} {p.User.Name} ({p.User.Email}) съел {p.Food.Name}").ToList(),
                        Hello = user.Posts.Count == 1 ?
                        $@"{user.Name}, мы рады приветствовать вас в нашем сообществе! Вы только что съели { lastFood.Name }! За сегодня { lastFood.Name } было съедено { countPostLastFoodToday } раз!" :
                        $@"{user.Name}, с возвращением! Вы только что съели { lastFood.Name }! Всего вы съели { lastFood.Name } { countPostLastFoodForUser } раз! За сегодня { lastFood.Name } было съедено { countPostLastFoodToday } раз!"
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}