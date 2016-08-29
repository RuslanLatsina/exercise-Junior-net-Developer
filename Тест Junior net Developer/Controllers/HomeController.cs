using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Тест_Junior_net_Developer.Models;


namespace Тест_Junior_net_Developer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string tag)
        {
            //зчитування данних про користувачів
            var data = JsonConvert.DeserializeObject<IEnumerable<Data>>(System.IO.File.ReadAllText(Server.MapPath(@"~/Data/data.json")));
            //виведення залогіненого користувача
            ViewBag.LogName = LogName();
            if (string.IsNullOrEmpty(tag))
            {
                return View(data);
            }
            //фільтрація користувачів по тегу
            data = data.Where(x => x.HasTag(tag));

            var viewModel = data.ToList();
            
            return View(viewModel);
        }
        //виведення аутенфікованого користувача
        public string LogName()
        {
            //зчитування користувачів
            var accounts = JsonConvert.DeserializeObject<List<Accounts>>(System.IO.File.ReadAllText(Server.MapPath(@"~/Data/accounts.json")));
            string currentName = null;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                Accounts account = accounts.FirstOrDefault(a => a.Login == HttpContext.User.Identity.Name);
                if (account != null)
                {
                    currentName = account.Name;
                }
            }
            return currentName;
        }
        public ActionResult Login()
        {
            return View();
        }
        // аутенфікація користувача
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
               //зчитування користувачів
               var accounts = JsonConvert.DeserializeObject<List<Accounts>>(System.IO.File.ReadAllText(Server.MapPath(@"~/Data/accounts.json")));
                //перевірка наявності користувача
                Accounts account = accounts.FirstOrDefault(a => a.Login == model.Login && a.Password == model.Password);
                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Користувача з таким логіном та паролем немає");
                }
            }

            return View(model);
        }
        //відображення детальної інформації про користувача
        public ActionResult Page(Guid guid)
        {
            var data = JsonConvert.DeserializeObject<List<Data>>(System.IO.File.ReadAllText(Server.MapPath(@"~/Data/data.json")));

            ViewBag.LogName = LogName();
            return View(data.SingleOrDefault(x => x.Guid == guid));
        }
    }
}