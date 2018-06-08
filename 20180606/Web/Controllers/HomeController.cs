using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Web.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:6001"),
                Timeout =  new TimeSpan(0, 20, 0)
            };
        }

        [HttpGet]
        [Route("api/v1/GetDaysOfMonth/{mes}")]
        public async Task<string> GetDaysOfMonth(string mes)
        {
            string dias = string.Empty;

            HttpResponseMessage response = await _httpClient.GetAsync($"Api/DaysOfMonth/{mes}");
            dias = response.Content.ReadAsStringAsync().Result;

            return dias;
        }

        [HttpGet]
        [Route("api/v1/GetCemeteryList")]
        public async Task<IActionResult> GetCemeteryList()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Api/CemeteryList");
            string format = response.Content.ReadAsStringAsync().Result;

            return Ok(format);
        }
    }
}
