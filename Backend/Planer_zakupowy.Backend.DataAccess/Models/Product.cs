using Planer_zakupowy.Backend.DataAccess.Models.Enums;

namespace Planer_zakupowy.Backend.DataAccess.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductsCategories Category { get; set; }
        public float? Price { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<ProductsList>? ProductsLists { get; set; }
    }
}
