using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Stock.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IStoreService _storeService;
        private readonly IItemService _itemService;
        public StockController(IStockService stockService, IStoreService storeService, IItemService itemService)
        {
            _stockService = stockService;
            _storeService = storeService;
            _itemService = itemService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Stores =await _storeService.GetListAsync();
            ViewBag.Items =await _itemService.FindAsync(i => i.SoftDelete == false);
            return View();
        }

        public async Task<IActionResult> GetQuantity([Required] Guid StoreId, [Required] Guid ItemId)
        {
            return Ok(await _stockService.GetItemQuantityInStock(StoreId, ItemId));
        }

        public async Task<IActionResult> AddQuantity([Required]Guid StoreId, [Required] Guid ItemId, [Required] uint Quantity)
        {
            return Ok(await _stockService.UpdateStock(StoreId, ItemId, Quantity));
        }

        public async Task<IActionResult> RemoveStock([Required] Guid StoreId, [Required] Guid ItemId)
        {
            return Ok(await _stockService.DeleteStock(StoreId, ItemId));
        }
    }
}
