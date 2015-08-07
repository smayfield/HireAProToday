using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireAProToday.Models
{
    public class DirectoryCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }

        public DirectoryCategory()
        {
            Members = new List<Member>();
        }
    }
}