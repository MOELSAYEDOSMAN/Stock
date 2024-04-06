namespace Stock.Service.DbModelService.StockModelService
{
    public interface IStockService
    {
        Task<int> GetItemQuantityInStock(Guid storeId, Guid itemId);
        Task<bool> UpdateStock(Guid storeId, Guid ItemId, uint Quantity);
        Task<int> DeleteStock(Guid storeId, Guid ItemId);
    }
}
