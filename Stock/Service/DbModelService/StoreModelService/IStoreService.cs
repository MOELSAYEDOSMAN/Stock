namespace Stock.Service.DbModelService.StoreModelService
{
    public interface IStoreService:IBaseService<Store>
    {
        /// <summary>
        /// Add New Store In Db
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Store> AddNewStore(StoreDTO input);
        /// <summary>
        /// Update Store In Db
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Store?> UpdateStore(Guid id, StoreDTO input);
        Task<bool> RemoveStore(Guid StoreId);
        
        /// <summary>
        /// Get Store Stock With Item
        /// </summary>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        Task<Store?> GetStocks(Guid StoreId);
        /// <summary>
        /// Serch With Name Like StoreName
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Task<List<Store>> SerchWithName(string Name);
    }
}
