using inphone_API.Model;

namespace inphone_API.Dtos
{
    public class ButtonsForDisplayDto
    {
        public int IdButton { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public TypeButton TypeButton { get; set; }
    }
}