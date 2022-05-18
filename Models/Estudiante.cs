using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampBrivé_Homework.Models
{
    public class Estudiante
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Career { get; set; } = "";

        public string Email { get; set; } = "";

        public bool Egresado { get; set; } 
    }
}
