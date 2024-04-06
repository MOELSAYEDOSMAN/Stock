namespace Stock.Service.DbModelService.StockModelService
{
    public class StockService:BaseService<Store>, IStockService
    {
        
        private readonly IItemService _itemService;

        public StockService(IItemService itemService,ApplicationDataBaseContext db):base(db)
        {
            _itemService = itemService;
        }

        public async Task<int> GetItemQuantityInStock(Guid storeId, Guid itemId)
        {
            var store = await FindByAsync(s => s.StoreId == storeId, new string[] { "Stocks" }, true);

            if (store == null)
                return -1;

            return
                store.Stocks.SingleOrDefault(i => i.ItemId == itemId)?.Quantity ?? 0;
        }

        public async Task<bool> UpdateStock(Guid storeId, Guid ItemId, uint Quantity)
        {
            Console.WriteLine(storeId);
            Console.WriteLine(ItemId);
            Console.WriteLine(Quantity);

            //Cheack store
            var store = await FindByAsync(s => s.StoreId == storeId, new string[] { "Stocks" });
            if (store == null)
                return false;
            //cheack Item
            var Item = await _itemService.FindByAsync(i => i.ItemId == ItemId, null, true);
            if (Item == null)
                return false;
            //Update Stock
            var storeItem = store.Stocks.SingleOrDefault(i => i.ItemId == ItemId);
            if (storeItem == null)
                store.Stocks.Add(new Models.DbModels.StoreModel.Stock()
                {
                    ItemId = ItemId,
                    StoreId = storeId,
                    Quantity = (int)Quantity
                });

            else
                storeItem.Quantity += (int)Quantity;
            await SaveChangesAsync();
            return true;
        }

        public async Task<int> DeleteStock(Guid storeId, Guid ItemId)
        {
            var store = await FindByAsync(s => s.StoreId == storeId, new string[] { "Stocks" });
            if (store == null)
                return 3;

            var stock = store.Stocks.SingleOrDefault(s => s.ItemId == ItemId);
            if(stock==null) 
                return 2;

            store.Stocks.Remove(stock);
            await SaveChangesAsync();
            return 1;
        }
    }
}
