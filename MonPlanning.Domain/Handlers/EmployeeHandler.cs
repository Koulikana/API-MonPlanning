using MonPlanning.Domain.Commands;
using MonPlanning.Domain.Dto;
using MonPlanning.Domain.Interfaces.IDal;
using MonPlanning.Domain.Interfaces.IDao;
using System.Threading.Tasks;

namespace MonPlanning.Domain.Handlers
{
    public class EmployeeHandler
    {
        private IEmployeeDal _employeeDal;

        public EmployeeHandler(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        /// <summary>
        /// Handles the GetEmployeeByMatricule command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task<IEmployeeDao> HandleAsync(GetEmployeeByMatriculeCommand command)
        {
            var employeeDto = EmployeeDto.InitEmployeeMatricule(command.Matricule);
            var employee = await _employeeDal.GetEmployeeByMatriculeAsync(employeeDto);

            return employee;
        }

        /// <summary>
        /// Handles the AddNewEmployee command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns></returns>
        public async Task HandleAsync(AddNewEmployeeCommand command)
        {
            var employeeDto = EmployeeDto.CreateNewEmployee(command.FirstName, command.LastName, command.BirthDate, command.Email, command.Password);

            await _employeeDal.AddNewEmployeeAsync(employeeDto);

        }

        /// <summary>
        /// Handles the DeleteEmployee command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns></returns>
        public async Task HandleAsync(DeleteEmployeeCommand command)
        {
            var employeeDto = EmployeeDto.InitEmployeeMatricule(command.Matricule);

            await _employeeDal.DeleteEmployeeAsync(employeeDto);
        }

        /// <summary>
        /// Handles the UpdateEmployee command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task HandleAsync(UpdateEmployeeCommand command)
        {
            var employeeDto = EmployeeDto.UpdateEmployee(command.Matricule, command.FirstName, command.LastName, command.BirthDate, command.Email, command.Password);

            await _employeeDal.UpdateEmployeeAsync(employeeDto);
        }
    }
}
