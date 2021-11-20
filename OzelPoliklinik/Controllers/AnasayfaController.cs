using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OzelPoliklinik.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OzelPoliklinik.Controllers
{
    public class AnasayfaController : Controller
    {
        private OzelPolikliniklerContext _context;

        public AnasayfaController(OzelPolikliniklerContext context)
        {
            _context = context;
        }


        public IActionResult Anasayfa()
        {
            var p = _context.Polikliniklers.ToList();

            return View();
        }



        public IActionResult VeriCek()
        {
            return View();
        }




        [HttpPost]
        public IActionResult VeriCek(IFormFile file)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);

                using (var workbook = new XLWorkbook(ms))
                {
                    var worksheet = workbook.Worksheet(1); // sayfa 1
                    // sayfada kaç sütun kullanılmış onu buluyoruz ve sütunları DataTable'a ekliyoruz, ilk satırda sütun başlıklarımız var
                    int i, n = worksheet.Columns().Count();
                    for (i = 1; i <= n; i++)
                    {
                        dt.Columns.Add(worksheet.Cell(1, i).Value.ToString());
                    }

                    // sayfada kaç satır kullanılmış onu buluyoruz ve DataTable'a satırlarımızı ekliyoruz
                    n = worksheet.Rows().Count();
                    for (i = 1; i <= n; i++)
                    {
                        DataRow dr = dt.NewRow();

                        int j, k = worksheet.Columns().Count();
                        for (j = 1; j <= k; j++)
                        {
                            // i= satır index, j=sütun index, closedXML worksheet için indexler 1'den başlıyor, ama datatable için 0'dan başladığı için j-1 diyoruz
                            dr[j - 1] = worksheet.Cell(i, j).Value;

                        }

                        if (i > 1)
                        {
                            Poliklinikler p = new Poliklinikler();
                            p.Sehir = dr.ItemArray[0].ToString();
                            p.Ilce = dr.ItemArray[1].ToString();
                            p.KurulusAdi = dr.ItemArray[2].ToString();
                            p.Adres = dr.ItemArray[3].ToString();
                            p.Telefon = dr.ItemArray[4].ToString();

                            string[] koordinat_parcala = dr.ItemArray[5].ToString().Split(",");

                            p.Koordinat1 = koordinat_parcala[0];
                            p.Koordinat2 = koordinat_parcala[1];

                            _context.Polikliniklers.Add(p);
                            _context.SaveChanges();
                        }


                        dt.Rows.Add(dr);
                    }
                }
            }

            // tablomuzu json formatına çeviriyoruz
            string json = JsonConvert.SerializeObject(dt);

            return Ok(json);
        }

    }
}
