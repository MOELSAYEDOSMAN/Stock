using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Stock.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService= storeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _storeService.GetListAsync());
        }

        [HttpGet(Name ="SerchStore")]
        public async Task<IActionResult> Index(string Name)
        {
            
            if(!string.IsNullOrEmpty(Name)||!string.IsNullOrWhiteSpace(Name))
                return View(await _storeService.SerchWithName(Name));
            else
                return View(await _storeService.GetListAsync());
        }



        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> ShowStore([Required]Guid Id)
        {
            var store=await _storeService.GetStocks(Id);
            return View(store);
        }

        public async Task<IActionResult> AddNewStore()
        {
            return View(new StoreDTO());
        }
        [HttpPost]
        public async Task<IActionResult> AddNewStore(StoreDTO input)
        {
            if(!ModelState.IsValid)
                return View(input);

           var store= await _storeService.AddNewStore(input);
            return RedirectToAction($"ShowStore", new { Id = store.StoreId });
        }

        public async Task<IActionResult> EditStore(Guid Id)
        {
            var output = await _storeService.GetAsync(Id);
            if (output != null)
                ViewBag.Icon = output?.Icon;
            return View((StoreDTO)output);
        }
        [HttpPost]
        public async Task<IActionResult> EditStore(StoreDTO input)
        {
            if (!ModelState.IsValid)
                return View(input);
            string id = (string)Request.RouteValues["Id"];
            var store = await _storeService.UpdateStore(Guid.Parse(id), input);
            return RedirectToAction($"ShowStore",new{Id=id});
        }

        [HttpGet]
        public async Task<IActionResult> RemoveStore([Required]Guid id)
        {
            Console.WriteLine(id);
            var result=await _storeService.RemoveStore(id);
            if (result == false)
                return Ok(false);

            return RedirectToAction("Index");
        }


    }
}
