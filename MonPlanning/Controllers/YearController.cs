using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonPlanning.Models;

namespace MonPlanning.Controllers
{
    [Route("planning/[controller]")]
    [ApiController]
    public class YearController : ControllerBase
    {
        readonly ContexteDonnees data;

        public YearController(ContexteDonnees _data)
        {
            data = _data;
        }

        // GET: planning/Year
        [HttpGet]
        public ActionResult<IEnumerable<Year>> Get()
        {
            return data.Years.Values.ToList();
        }

        // GET: planning/Year/5
        [HttpGet("{year}")]
        public ActionResult<Year> GetYear(int year)
        {
            return data.Years[year];
        }

        // POST: planning/Year
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: planning/Year/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: planning/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
