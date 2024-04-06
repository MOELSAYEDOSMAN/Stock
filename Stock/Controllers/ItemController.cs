using Microsoft.AspNetCore.Mvc;
using Stock.Models.DbModels.StoreModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService=itemService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _itemService.GetListAsync());
        }
        [HttpGet(Name = "SerchItem")]
        public async Task<IActionResult> Index(string Name)
        {
            if (!string.IsNullOrEmpty(Name) || !string.IsNullOrWhiteSpace(Name))
                return View(await _itemService.SerchWithName(Name));
            else
                return View(await _itemService.GetListAsync());
        }


        [HttpGet("GetItem/{Id}")]
        public async Task<IActionResult> GetItem([Required] Guid Id)
        {
            var item = await _itemService.GetAsync(Id);
            return View(item);
        }

        public async Task<IActionResult> AddNewItem()
        {
            return View(new ItemDTO());
        }
        [HttpPost]
        public async Task<IActionResult> AddNewItem(ItemDTO input)
        {
            if(!ModelState.IsValid)
                return View(input);
            var item= await _itemService.AddNewItemAsync(input);
            return RedirectToAction($"GetItem", new { Id = item.ItemId });
            
        }


        public async Task<IActionResult> EditItem(Guid Id)
        {
            var output = await _itemService.GetAsync(Id);
            if (output != null)
            {
                ViewBag.Icon = output?.Icon;
                ViewBag.Images=output?.Images;
                ViewBag.Id = Id;
            }
            return View((ItemDTO)output);
        }
        [HttpPost]
        public async Task<IActionResult> EditItem(ItemDTO input)
        {
            if (!ModelState.IsValid)
                return View(input);
            string id = (string)Request.RouteValues["Id"];
            var store = await _itemService.UpdateItemAsync(Guid.Parse(id), input);
            return RedirectToAction($"GetItem", new { Id = id });
        }

        public async Task<IActionResult> RemoveItem([Required]Guid id)
        {
            return Ok(await _itemService.RemoveItem(id));
        }

        public async Task<IActionResult> RemoveImage([Required] Guid id,[Required]string src)
        {
            if (string.IsNullOrEmpty(src) || string.IsNullOrWhiteSpace(src))
                return Ok(false);
            else
            {
                if (await _itemService.RemoveImageItem(id, src))
                    return Ok(true);
                else
                    return Ok(false);
            }
        }
    }
}
