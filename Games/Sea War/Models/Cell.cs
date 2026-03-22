using Sea_War.Models.Enums;

namespace Sea_War.Models
{
    public class Cell
    {
        private TypeCell Value { get; set; }

        public Cell(TypeCell type)
        {
            Value = type;
        }
    }
}
