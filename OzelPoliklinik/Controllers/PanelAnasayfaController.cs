using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelPoliklinik.Controllers
{
    public class PanelAnasayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
