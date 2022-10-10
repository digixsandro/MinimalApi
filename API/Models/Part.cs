using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public int Weight_Ounces { get; set; }
        public bool Is_Active { get; set; }

        public Part() { }

        public Part(string name, string sku, string description, int weightOunces, bool isActive)
        {
            Name = name;
            Sku = sku;
            Description = description;
            Weight_Ounces = weightOunces;
            Is_Active = Is_Active;
        }

        public void Update(string name, string sku, string description, int weightOunces, bool isActive)
        {
            Name = name;
            Sku = sku;
            Description = description;
            Weight_Ounces = weightOunces;
            Is_Active = Is_Active;
        }
    }
}
