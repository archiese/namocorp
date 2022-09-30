using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class AddressBook
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
    }
}