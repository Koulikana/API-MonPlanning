using System;
using System.Collections.Generic;
using System.Text;

namespace MonPlanning.Domain.Commands
{
    public class DeleteEmployeeCommand
    {
        public int Matricule { get; set; }
    }
}
