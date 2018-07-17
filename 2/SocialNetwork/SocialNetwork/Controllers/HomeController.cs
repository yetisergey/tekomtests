using Business;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return View();
        }

        [Authorize]
        public ActionResult History()
        {
            return View();
        }
    }
}
