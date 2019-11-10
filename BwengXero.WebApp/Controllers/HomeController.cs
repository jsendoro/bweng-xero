using BwengXero.Core;
using System.Web.Mvc;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Infrastructure.OAuth;

namespace BwengXero.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IMvcAuthenticator _authenticator;
        private ApiUser _user;

        public HomeController()
        {
            _authenticator = XeroApiHelper.MvcAuthenticator();
            _user = XeroApiHelper.User();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Connect()
        {
            var authorizeUrl = _authenticator.GetRequestTokenAuthorizeUrl(_user.Name);
            return Redirect(authorizeUrl);
        }

        public ActionResult Authorize(string oauth_token, string oauth_verifier, string org)
        {
            _authenticator.RetrieveAndStoreAccessToken(_user.Name, oauth_token, oauth_verifier, org);
            return RedirectToAction("Index", "Organisation");
        }
    }
}