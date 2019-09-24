using System;
using System.Collections.Generic;
using System.Text;

namespace MonPlanning.Domain.Commands
{
    public class GetEmployeeByMatriculeCommand
    {
        public int Matricule { get; set; }
    }
}
