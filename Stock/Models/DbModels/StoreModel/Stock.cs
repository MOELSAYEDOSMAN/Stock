using Microsoft.EntityFrameworkCore;
using Stock.Models.DbModels.ItemModel;

namespace Stock.Models.DbModels.StoreModel
{
    [Owned]
    public class Stock
    {
        public Guid StoreId { get; set; }
        public Store Store { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
