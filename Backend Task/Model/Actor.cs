using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
   public class Actor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string  Sex { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
