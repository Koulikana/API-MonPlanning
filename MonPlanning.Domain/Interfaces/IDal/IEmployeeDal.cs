using MonPlanning.Domain.Dto;
using MonPlanning.Domain.Interfaces.IDao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonPlanning.Domain.Interfaces.IDal
{
    public interface IEmployeeDal
    {
        Task<IReadOnlyCollection<IEmployeeDao>> GetAllEmployeesAsync();

        Task<IEmployeeDao> GetEmployeeByMatriculeAsync(EmployeeDto matricule);

        Task AddNewEmployeeAsync(EmployeeDto employee);

        Task UpdateEmployeeAsync(EmployeeDto matricule);

        Task DeleteEmployeeAsync(EmployeeDto matricule);
    }
}
