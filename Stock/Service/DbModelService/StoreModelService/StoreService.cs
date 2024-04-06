using Microsoft.EntityFrameworkCore;
using Stock.Models.DbModels.ItemModel;
using System.Security.Cryptography.X509Certificates;

namespace Stock.Service.DbModelService.StoreModelService
{
    public class StoreService: BaseService<Store>,IStoreService
    {
        private readonly IFIleService _fileService;
        
        public StoreService(ApplicationDataBaseContext db,IFIleService fIleService) :base(db)
        {
            _fileService = fIleService;
        }

        public async Task<Store> AddNewStore(StoreDTO input)
        {
            Store store = input;
            if (input?.Icon != null)
                store.Icon = await _fileService.UploadFileAsync(input.Icon, "Store");
            else
                store.Icon = "Store/Store.webp";

            return await AddAsync(store);
        }
        
        public async Task<Store?> UpdateStore(Guid id, StoreDTO input)
        {
            Store store = await GetAsync(id);
            
            if(store == null)
                return null;

            if(input.Icon!=null)
                if (store?.Icon != "Store/Store.webp")
                    await _fileService.ChangeImgageAsync(store.Icon, input.Icon);
                else
                    store.Icon = await _fileService.UploadFileAsync(input.Icon, "Store");

            store = input.ReturnStore(store);
            return await UpdateAsync(store);
        }
        
        public async Task<bool> RemoveStore(Guid StoreId)
        {
            var store = await GetAsync(StoreId);
            if (store == null)
                return false;
            if (store.Icon != "Store/Store.webp")
                await _fileService.RemoveFileAsync(store.Icon);
            await DeleteAsync(store);
            return true;
        }
        
        public async Task<List<Store>> SerchWithName(string Name)
        {
            var result = await FindAsync(s => s.Name.ToUpper().Contains(Name.ToUpper()));
            return result.ToList();
        }
        
        public async Task<Store> GetStocks(Guid StoreId)
        {
            var store= await _db.Stores.
                Include(s => s.Stocks).ThenInclude(d=>d.Item)
                .SingleOrDefaultAsync(s => s.StoreId == StoreId);
            return store;
            
        }

        
    }
}
