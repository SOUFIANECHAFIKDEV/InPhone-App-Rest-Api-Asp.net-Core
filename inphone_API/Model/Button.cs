using System;

namespace inphone_API.Model
{
    public class Button
    {
        public int IdButton { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public int IdCustomer { get; set; }
        public DateTime LastModificationDate { get; set; }
        public Customer Customer { get; set; }
        public TypeButton TypeButton { get; set; }
    }
}