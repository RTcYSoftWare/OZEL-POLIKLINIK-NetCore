using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelPoliklinik.Controllers
{
    public class PanelLoginController : Controller
    {
        public IActionResult PanelAdminGiris()
        {
            return View();
        }


        [HttpPost]
        public IActionResult PanelAdminGiris(string e_mail, string sifre)
        {



            return View();
        }

    }
}
