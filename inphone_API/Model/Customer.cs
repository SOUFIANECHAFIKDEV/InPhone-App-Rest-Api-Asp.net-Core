using System;
using System.Collections.Generic;

namespace inphone_API.Model
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo1 { get; set; }
        public string Logo2 { get; set; }
        public string Logo3 { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public IEnumerable<Button> Buttons { get; set; }
    }
}