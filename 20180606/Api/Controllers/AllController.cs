using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Newtonsoft.Json;
using System.Text;

namespace Api.Controllers
{
    public class AllController : ControllerBase
    {
        private readonly AllContext _context;

        public AllController(AllContext context)
        {
            _context = context;

            if (_context.AllItems.Count() == 0)
            {
                _context.AllItems.Add(new AllItem { Name = "Item1" });
                _context.AllItems.Add(new AllItem { Name = "Item2" });
                _context.SaveChanges();
            }
        }

        private string GetDataFromBody()
        {
            if (!this.Request.ContentLength.HasValue)
            {
                return null;
            }
            int len = (int)(this.Request.ContentLength ?? 0);
            byte[] buff = new byte[len];
            this.Request.Body.Read(buff, 0, len);
            string result = Encoding.Default.GetString(buff);
            return result;
        }

        [HttpGet]
        [Route("Api/All")]
        public ActionResult<string> GetAll()
        {
            return JsonConvert.SerializeObject(_context.AllItems.ToList());
        }

        [HttpGet]
        [Route("Api/All/{id}")]
        public ActionResult<string> GetById(long id)
        {
            var item = _context.AllItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return JsonConvert.SerializeObject(item);
        }

        [HttpPost]
        [Route("Api/Create")]
        public ActionResult Create()
        {
            string data = GetDataFromBody();
            AllItem result = JsonConvert.DeserializeObject<AllItem>(data);
            _context.AllItems.Add(result);
            _context.SaveChanges();
            return CreatedAtRoute("GetTodo", new { id = result.Id }, result);
        }

        [HttpPut]
        [Route("Api/Edit/{id}")]
        public IActionResult Update(long id)
        {
            string data = GetDataFromBody();
            AllItem item = JsonConvert.DeserializeObject<AllItem>(data);

            var all = _context.AllItems.Find(id);
            if (all == null)
            {
                return NotFound();
            }

            all.IsComplete = item.IsComplete;
            all.Name = item.Name;

            _context.AllItems.Update(all);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("Api/Delete/{id}")]
        public IActionResult Delete(long id)
        {
            var all = _context.AllItems.Find(id);
            if (all == null)
            {
                return NotFound();
            }

            _context.AllItems.Remove(all);
            _context.SaveChanges();
            return NoContent();
        }
    }
}