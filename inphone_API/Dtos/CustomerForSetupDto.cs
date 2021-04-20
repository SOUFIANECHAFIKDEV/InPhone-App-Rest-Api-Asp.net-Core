using System;
using System.Collections.Generic;

namespace inphone_API.Dtos
{
    public class CustomerForSetupDto
    {
        public Nullable<int> IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo1 { get; set; }
        public string Logo2 { get; set; }
        public string Logo3 { get; set; }
        public IEnumerable<ButtonForSetupDto> Buttons { get; set; }
    }
}
