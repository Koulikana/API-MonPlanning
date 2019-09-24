using Dapper;
using MonPlanning.Domain.Dto;
using MonPlanning.Domain.Interfaces.IDal;
using MonPlanning.Domain.Interfaces.IDao;
using MonPlanning.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MonPlanning.Infrastructure.Dal
{
    public class EmployeeDal : IEmployeeDal
    {
        private readonly Func<IDbConnection> _connectionProvider;

        public EmployeeDal(Func<IDbConnection> connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        /// <summary>
        /// Gets a list of all employees
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<IEmployeeDao>> GetAllEmployeesAsync()
        {
            IEnumerable<IEmployeeDao> employees = null;

            using (var connection = _connectionProvider())
            {
                employees = await connection.QueryAsync<EmployeeDao>(
                    EmployeesQueries.GetAllEmployees,
                    commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);

            }

            return employees.AsList();
        }

        /// <summary>
        /// Inserts a new employee
        /// </summary>
        /// <param name="employee">An instance of <see cref="IEmployeeDao"/></param>
        /// <returns></returns>
        public async Task AddNewEmployeeAsync(EmployeeDto employee)
        {
            using (var connection = _connectionProvider())
            {
                await connection.ExecuteAsync(
                    EmployeesQueries.InsertEmployee,
                    new
                    {
                        employee.FirstName,
                        employee.LastName,
                        employee.BirthDate,
                        employee.Email,
                        employee.Password
                    },
                    commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Updates an employee's information
        /// </summary>
        /// <param name="employee">The employee's new information</param>
        /// <returns></returns>
        public async Task UpdateEmployeeAsync(EmployeeDto employee)
        {
            using (var connection = _connectionProvider())
            {
                await connection.ExecuteAsync(
                    EmployeesQueries.UpdateEmployee,
                    new
                    {
                        employee.Matricule,
                        employee.FirstName,
                        employee.LastName,
                        employee.BirthDate,
                        employee.Email,
                        employee.Password
                    },
                    commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets an employee by the matricule
        /// </summary>
        /// <param name="matricule">The employee's matricule</param>
        /// <returns></returns>
        public async Task<IEmployeeDao> GetEmployeeByMatriculeAsync(EmployeeDto matricule)
        {
            IEmployeeDao employee = null;

            using (var connection = _connectionProvider())
            {
                employee = await connection.QueryFirstOrDefaultAsync<EmployeeDao>(
                    EmployeesQueries.GetEmployeeByMatricule,
                    new { matricule.Matricule },
                    commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
            }

            return employee;
        }

        /// <summary>
        /// Deletes an employee by the matricule
        /// </summary>
        /// <param name="matricule">The employee's matricule</param>
        /// <returns></returns>
        public async Task DeleteEmployeeAsync(EmployeeDto matricule)
        {
            using (var connection = _connectionProvider())
            {
                await connection.ExecuteAsync(
                    EmployeesQueries.DeleteEmployee,
                    new { matricule.Matricule },
                    commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
            }
        }

        public static class EmployeesQueries
        {
            internal const string GetAllEmployees = "ps_employee_select_all";
            internal const string GetEmployeeByMatricule = "ps_employee_select_by_matricule";
            internal const string UpdateEmployee = "ps_employee_update";
            internal const string InsertEmployee = "ps_employee_insert";
            internal const string DeleteEmployee = "ps_employee_delete";
        }
    }
}
