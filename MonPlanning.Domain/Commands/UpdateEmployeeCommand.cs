﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MonPlanning.Domain.Commands
{
    public class UpdateEmployeeCommand
    {
        public int Matricule { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
