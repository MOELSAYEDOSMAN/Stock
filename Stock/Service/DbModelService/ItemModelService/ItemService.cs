using Stock.Models.DbModels.ItemModel;

namespace Stock.Service.DbModelService.ItemModelService
{
    public class ItemService : BaseService<Item>, IItemService
    {
        private readonly IFIleService _fileService;
        public ItemService(ApplicationDataBaseContext db, IFIleService fileService) : base(db)
        {
            _fileService = fileService;
        }


        public async Task<List<Item>> GetListAsync()
        {
            var result = await FindAsync(i => i.SoftDelete==false, null, true);
            return result.ToList();
        }

        public async Task<Item> AddNewItemAsync(ItemDTO input)
        {
            Item item = input;
            //Save Icon Image
            if (input?.Icon != null)
                item.Icon = await _fileService.UploadFileAsync(input.Icon, "Item");
            else
                item.Icon = "Item/Item.webp";
            //Save Other Images
            if (input?.Images != null)
            {
                var images = await _fileService.UploadFilesAsync(input.Images, "Item");
                foreach (string img in images)
                    item.Images.Add(img);
            }

            //Add in Db
            return await AddAsync(item);
        }

        public async Task<Item?> UpdateItemAsync(Guid itemId, ItemDTO input)
        {
            var item = await GetAsync(itemId);
            if (item == null)
                return null;

            //Change Icon
            if (input?.Icon != null)
                if (item?.Icon != "Item/Item.webp")
                    await _fileService.ChangeImgageAsync(item.Icon, input.Icon);
                else
                    item.Icon = await _fileService.UploadFileAsync(input.Icon, "Item");

            //add New Image
            if (input?.Images != null)
            {
                var images = await _fileService.UploadFilesAsync(input.Images, "Item");
                images.ForEach(image => {
                    item.Images.Add(image);
                });
            }

            item = input.ReturnItem(item);


            return await UpdateAsync(item);
        }

        public async Task<bool> RemoveItem(Guid ItemId)
        {
            var item = await FindByAsync(i => i.ItemId == ItemId);
            if (item == null)
                return false;
            if (item.Icon != "Item/Item.webp")
                await _fileService.RemoveFileAsync(item.Icon);

            var images = item.Images.Select(i => i.Src).ToList();
            await _fileService.RemoveFilesAsync(images);

            item.Images.Clear();
            item.Icon = "Item/Item.webp";
            item.SoftDelete = true;
            await UpdateAsync(item);
            return true;
        }

        public async Task<bool> RemoveImageItem(Guid itemId, string fileName)
        {
            var item = await GetAsync(itemId);
            Console.WriteLine(1);
            if (item == null)
                return false;
            var img = item.Images.SingleOrDefault(i => i.Src == fileName);
            if (img == null)
                return false;
            await _fileService.RemoveFileAsync(fileName);
            item.Images.Remove(img);
            await SaveChangesAsync();
            return true;
        }
       
            
        public async Task<List<Item>> SerchWithName(string Name)
        {
            var result = await FindAsync(i=>i.SoftDelete==false&&i.Name.ToUpper().Contains(Name.ToUpper()));
            return result.ToList();
        }

    }
}
