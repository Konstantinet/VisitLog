using CsvHelper.Configuration.Attributes;
using System;

namespace AutoLister
{
    public class Student : IEquatable<Student>
    {


        [Name(" Full Name")]
        public string FullName { get; set; }

        public bool Equals(Student other)
        {
            return FullName.Equals(other.FullName);
        }
        public override int GetHashCode()
        {
            return FullName.GetHashCode();
        }

        public override string ToString()
        {
            return FullName;
        }

    }
}

