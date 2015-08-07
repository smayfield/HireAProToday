using System;
using System.Collections.Generic;

namespace HireAProToday.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
        public string Url { get; set; }
        public MemberType MemberType { get; set; }
        public decimal DuesPaid { get; set; }
        public List<DirectoryCategory> Categories { get; set; } 

    }
}