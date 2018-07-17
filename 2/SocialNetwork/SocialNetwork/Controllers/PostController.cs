namespace SocialNetwork.Controllers
{
    using Business;
    using DTOs;
    using System;
    using System.Web.Http;
    using System.Web.Security;
    using Utils;

    public class PostController : ApiController
    {
        public IHttpActionResult Post([FromBody]PostDto value)
        {
            try
            {
                if (string.IsNullOrEmpty(value.Name))
                    throw new Exception("Неправильно заполнено Имя!");

                if (!Validation.IsValidEmail(value.Email))
                    throw new Exception("Неправильно заполнен Email!");

                if (value.FoodId == 0)
                    throw new Exception("Неправильно заполнена Еда!");

                using (var core = new Core())
                {
                    var user = core.GetUser(value.Name, value.Email);

                    if (user == null)
                        user = core.AddUser(value.Name, value.Email);

                    core.AddPost(user, value.FoodId);

                    if (!User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                    }

                    return Ok("Успех");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}