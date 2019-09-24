using System;

namespace MonPlanning.Domain.Dto
{
    public class EmployeeDto
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

        /// <summary>
        /// Creates a new instance of <see cref="EmployeeDto"/>
        /// </summary>
        /// <param name="matricule">The employee's matricule</param>
        /// <param name="firstName">The employee's first name</param>
        /// <param name="lastName">The employee's last name</param>
        /// <param name="birthDate">The employee's birthday</param>
        /// <param name="email">The employee's email</param>
        /// <param name="password">The employee's password</param>
        private EmployeeDto(int matricule, string firstName, string lastName, DateTime birthDate, string email, string password)
        {
            Matricule = matricule;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Creates a new instance <see cref="EmployeeDto"/>
        /// </summary>
        /// <param name="matricule">The employee's matricule</param>
        internal EmployeeDto(int matricule)
        {
            Matricule = matricule;
        }

        /// <summary>
        /// Creates a new instance of <see cref="EmployeeDto"/>
        /// </summary>
        /// <param name="firstName">The employee's first name</param>
        /// <param name="lastName">The employee's last name</param>
        /// <param name="birthDate">The employee's birthday</param>
        /// <param name="email">The employee's email</param>
        /// <param name="password">The employee's password</param>
        private EmployeeDto(string firstName, string lastName, DateTime birthDate, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Creates a new instance of <see cref="EmployeeDto"/> with a matricule
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns></returns>
        public static EmployeeDto InitEmployeeMatricule(int matricule)
        {
            return new EmployeeDto(matricule);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EmployeeDto"/>
        /// </summary>
        /// <param name="firstName">The employee's first name</param>
        /// <param name="lastName">The employee's last name</param>
        /// <param name="birthDate">The employee's birthday</param>
        /// <param name="email">The employee's email</param>
        /// <param name="password">The employee's password</param>
        public static EmployeeDto CreateNewEmployee(string firstName, string lastName, DateTime birthDate, string email, string password)
        {
            return new EmployeeDto(firstName, lastName, birthDate, email, password);
        }


        /// <summary>
        /// Updates employee's information
        /// </summary>
        /// <param name="matricule">The employee's matricule</param>
        /// <param name="firstName">The employee's first name</param>
        /// <param name="lastName">The employee's last name</param>
        /// <param name="birthDate">The employee's birthday</param>
        /// <param name="email">The employee's email</param>
        /// <param name="password">The employee's password</param>
        public static EmployeeDto UpdateEmployee(int matricule, string firstName, string lastName, DateTime birthDate, string email, string password)
        {
            return new EmployeeDto(matricule, firstName, lastName, birthDate, email, password);
        }
    }
}
