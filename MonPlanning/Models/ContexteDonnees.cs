using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonPlanning.Models
{
    public class ContexteDonnees
    {
        readonly Dictionary<int, Employee> employeesList;
        readonly Dictionary<int, Calendar> months;
        readonly Dictionary<string, DaysOption> optionsList;
        readonly Dictionary<int, Year> years;

        public ContexteDonnees()
        {
            employeesList = new Dictionary<int, Employee>();
            months = new Dictionary<int, Calendar>();
            optionsList = new Dictionary<string, DaysOption>();
            years = new Dictionary<int, Year>();
        }

        public void AddEmployee(Employee employee)
        {
            employeesList.Add(employee.Id ,employee);
        }

        public void AddMonth(Calendar month)
        {
            months.Add(month.Code, month);
        }

        public void AddOption(DaysOption option)
        {
            optionsList.Add(option.Value, option);
        }

        public void AddYear(Year year)
        {
            years.Add(year.Year_, year);
        }

        public IReadOnlyDictionary<int, Employee> EmployeeById => employeesList;
        public IReadOnlyDictionary<int, Calendar> MonthById => months;
        public IReadOnlyDictionary<string, DaysOption> OptionsByValue => optionsList;
        public IReadOnlyDictionary<int, Year> Years => years;
    }
}
