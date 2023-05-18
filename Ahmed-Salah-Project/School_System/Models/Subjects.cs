using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Models
{
    public class Subjects
    {
        public string Name { get; set; }
        public Subjects() { }
        public Subjects(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
