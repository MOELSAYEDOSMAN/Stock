namespace Stock.Service.DbModelService.ItemModelService
{
    public interface IItemService:IBaseService<Item>
    {
        /// <summary>
        /// Add New Item,Convert Image to Src
        /// </summary>
        /// <returns></returns>
        Task<Item> AddNewItemAsync(ItemDTO input);
        /// <summary>
        /// Change item Data ,ICon , Add New Images
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Item?> UpdateItemAsync(Guid itemId, ItemDTO input);
        /// <summary>
        /// soft Delte
        /// </summary>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        Task<bool> RemoveItem(Guid ItemId);
        /// <summary>
        /// Remove Image
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<bool> RemoveImageItem(Guid itemId, string fileName);
        /// <summary>
        /// Serch With Name 'Like'
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Task<List<Item>> SerchWithName(string Name);
        Task<List<Item>> GetListAsync();
    }
}
