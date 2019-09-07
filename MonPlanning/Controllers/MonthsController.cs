using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonPlanning.Domain.Commands;
using MonPlanning.Domain.Handlers;
using MonPlanning.Domain.Interfaces.IDal;
using MonPlanning.Domain.Interfaces.IDao;

namespace MonPlanning.Api.Controllers
{
    [Route("planning/[controller]")]
    [ApiController]
    public class MonthsController : ControllerBase
    {
        private readonly IMonthDal _monthDal;
        private readonly MonthHandler _monthHandler;

        public MonthsController(IMonthDal monthDal, MonthHandler monthHandler)
        {
            _monthDal = monthDal;
            _monthHandler = monthHandler;
        }

        // GET: api/Month
        [HttpGet]
        public async Task<IReadOnlyCollection<IMonthDao>> Get()
        {
            IReadOnlyCollection<IMonthDao> months = await _monthDal.GetAllMonthsAsync();

            return months;
        }

        // GET: api/Month/5
        [HttpGet("{id}", Name = "GetMonth")]
        public async Task<IMonthDao> Get(int id)
        {
            var command = new GetMonthByIdCommand { monthId = id };
            IMonthDao month = await _monthHandler.HandleAsync(command).ConfigureAwait(false);

            return month;
        }

        // POST: api/Month
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Month/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
