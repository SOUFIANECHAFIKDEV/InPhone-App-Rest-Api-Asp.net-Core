using System.Collections.Generic;

namespace inphone_API.Model
{
    public class TypeButton
    {
        public int IdTypeButton { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public IEnumerable<Button> Buttons { get; set; }
    }
}