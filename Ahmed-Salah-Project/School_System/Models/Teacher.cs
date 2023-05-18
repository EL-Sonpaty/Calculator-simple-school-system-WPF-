using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Models
{
    public class Teacher
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public string Image { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
        public Teacher() { }
    }

    public enum Subject
    {
        Arabic,
        English,
        Math

    }
}
