using BwengXero.Core.Actions;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Web.Mvc;
using Xero.Api.Example.Applications.Public;

namespace BwengXero.WebApp.Controllers
{
    public class OrganisationController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var organisation = OrganisationAction.GetOrganisation();
                return View(organisation);
            }
            catch (RenewTokenException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Account()
        {
            try
            {
                var accounts = AccountAction.GetAllAccounts();
                return View(accounts);
            }
            catch (RenewTokenException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Vendor()
        {
            try
            {
                var vendors = VendorAction.GetAllVendors();
                return View(vendors);
            }
            catch (RenewTokenException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Download(string type)
        {
            string fileContent;
            string outputFileName;

            if (string.Equals(type, "account", StringComparison.OrdinalIgnoreCase))
            {
                fileContent = JsonConvert.SerializeObject(AccountAction.GetAllAccounts());
                outputFileName = "accounts.txt";
            }
            else //"vendor"
            {
                fileContent = JsonConvert.SerializeObject(VendorAction.GetAllVendors());
                outputFileName = "vendor.txt";
            }
            byte[] data = Encoding.UTF8.GetBytes(fileContent);
            return File(data, "text/plain", outputFileName);
        }
    }
}
