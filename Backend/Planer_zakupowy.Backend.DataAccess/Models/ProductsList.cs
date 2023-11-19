using Planer_zakupowy.Backend.DataAccess.Models.Enums;

namespace Planer_zakupowy.Backend.DataAccess.Models
{
    public class ProductsList
    {
        public Guid ShoppingListId { get; set; }
        public Guid ProductId { get; set; }
        public ProductStatusOnList ProductStatusOnList { get; set; }
        public float PriceOfBoughtProducts { get; set; }
        public DateTime ProductInsertionDate { get; set; }
        public DateTime ProductBoughtDate { get; set; }

        public ShoppingList ShoppingList { get; set; }
        public Product Product { get; set; }
    }
}
