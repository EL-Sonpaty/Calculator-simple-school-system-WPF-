using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subjects_ { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
