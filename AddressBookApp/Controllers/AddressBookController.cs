using Microsoft.AspNetCore.Mvc;

namespace AddressBookApp.Controllers
{
    public class AddressBookController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
