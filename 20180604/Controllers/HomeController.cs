using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _20180604.Models;
using Newtonsoft.Json;

namespace _20180604.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Cemetery> _cemeteryList;

        public HomeController()
        {
            ListAllCemetery();
        }

        private void ListAllCemetery()
        {
            _cemeteryList = new List<Cemetery>(){
                new Cemetery(){
                    IdCemetery = "CEM001",
                    Name = "Cemetery 01",
                    Amount = 123,
                    Date = System.DateTime.Now
                },
                new Cemetery(){
                    IdCemetery = "CEM002",
                    Name = "Cemetery 02",
                    Amount = 567,
                    Date = System.DateTime.Now
                }
            };
        }

        bool GetCemetery(out string format)
        {
            List<Cemetery> cemetery = _cemeteryList.ToList();
            format = JsonConvert.SerializeObject(cemetery);

            return true;
        }

        [HttpGet]
        [Route("home/api/v1/GetDaysOfMonth/{mes}")]
        public string GetDaysOfMonth(string mes)
        {
            string dias = string.Empty;
            if (mes == "1")
            {
                dias = "31";
            }
            else if (mes == "2")
            {
                dias = "29";
            }
            else
            {
                dias = "30";
            }
            return dias;
        }

        [HttpGet]
        [Route("home/api/v1/GetCemeteryList")]
        public IActionResult GetCemeteryList()
        {
            bool a = GetCemetery(out string format);

            return Ok(format);
        }
    }
}
