using Planer_zakupowy.Backend.DataAccess.Models.Enums;

namespace Planer_zakupowy.Backend.DataAccess.Models
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndShoppingDate { get; set; }
        public ShoppingListStatus ShoppingListStatus { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public ICollection<ProductsList>? ProductsLists { get; set; }
    }
}
