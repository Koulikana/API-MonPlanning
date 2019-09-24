using System;
using System.Collections.Generic;
using System.Text;

namespace MonPlanning.Domain.Interfaces.IDao
{
    public interface IEmployeeDao
    {
        /// <summary>
        /// Gets or sets the employee's matricule
        /// </summary>
        int Matricule { get; set; }

        /// <summary>
        /// Gets or sets the employee's first name
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or set the employee last name
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the employee's birthday
        /// </summary>
        DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the employee's email address
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or set the employee's password
        /// </summary>
        string Password { get; set; }

    }
}
