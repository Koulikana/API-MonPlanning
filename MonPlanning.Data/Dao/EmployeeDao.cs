using MonPlanning.Domain.Interfaces.IDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonPlanning.Infrastructure.Dao
{
    public class EmployeeDao : IEmployeeDao
    {
        /// <summary>
        /// Gets or sets the employee's matricule
        /// </summary>
        public int Matricule { get; set; }

        /// <summary>
        /// Gets or sets the employee's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or set the employee last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the employee's birthday
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the employee's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or set the employee's password
        /// </summary>
        public string Password { get; set; }
    }
}
