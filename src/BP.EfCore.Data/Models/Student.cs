using System;
using System.Collections.Generic;

namespace BP.EfCore.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Number { get; set; }
        public int AddressId { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
        public virtual ICollection<StudentBook> Books { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}