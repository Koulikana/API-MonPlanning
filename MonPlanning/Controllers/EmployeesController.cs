using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonPlanning.Domain.Commands;
using MonPlanning.Domain.Handlers;
using MonPlanning.Domain.Interfaces.IDal;
using MonPlanning.Domain.Interfaces.IDao;

namespace MonPlanning.Api.Controllers
{
    [Route("planning/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeDal _employeeDal;
        private readonly EmployeeHandler _employeeHandler;

        public EmployeesController(IEmployeeDal employeeDal, EmployeeHandler employeeHandler)
        {
            _employeeDal = employeeDal;
            _employeeHandler = employeeHandler;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IReadOnlyCollection<IEmployeeDao>> Get()
        {
            IReadOnlyCollection<IEmployeeDao> employees = await _employeeDal.GetAllEmployeesAsync();

            return employees;
        }

        // GET: api/Employees/5
        [HttpGet("{matricule}", Name = "Get")]
        public async Task<IEmployeeDao> Get(int matricule)
        {
            var command = new GetEmployeeByMatriculeCommand { Matricule = matricule };
            IEmployeeDao employee = await _employeeHandler.HandleAsync(command).ConfigureAwait(false);

            return employee;
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddNewEmployeeCommand command)
        {
            await _employeeHandler.HandleAsync(command).ConfigureAwait(false);

            return StatusCode(201);
        }

        // PUT: api/Employees/5
        [HttpPut("{matricule}")]
        public async Task<ActionResult> Put(int matricule, [FromBody] UpdateEmployeeCommand command)
        {
            await _employeeHandler.HandleAsync(command).ConfigureAwait(false);

            return StatusCode(204);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{matricule}")]
        public async Task<ActionResult> Delete(int matricule)
        {
            var command = new DeleteEmployeeCommand { Matricule = matricule };

            await _employeeHandler.HandleAsync(command).ConfigureAwait(false);

            return StatusCode(204);
        }
    }
}
