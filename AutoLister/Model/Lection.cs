using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLister
{
    public class Lection
    {

        public Lection(List<Student> students,string Theme,DateTime Time)
        {
            Students = students.Distinct().ToList<Student>();
            this.Theme = Theme;
            this.Time = Time;
        }
        public List<Student> Students;

        public string Theme;

        public DateTime Time;

        public List<Group> Groups;
    }
}
