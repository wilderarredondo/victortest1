using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private List<Cemetery> _cemeteryList;

        public ValuesController()
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

        void GetCemetery(out string format)
        {
            List<Cemetery> cemetery = _cemeteryList.ToList();
            format = JsonConvert.SerializeObject(cemetery);
        }

        [HttpGet]
        [Route("/Api/DaysOfMonth/{mes}")]
        public IActionResult GetDaysOfMonth(string mes)
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
            return Ok(dias);
        }

        [HttpGet]
        [Route("/Api/CemeteryList")]
        public IActionResult GetCemeteryList()
        {
            GetCemetery(out string format);

            return Ok(format);
        }
    }
}
