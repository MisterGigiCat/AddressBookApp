using AddressBookApp.Data;
using AddressBookApp.Models;
using AddressBookApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressBookApp.Controllers
{
    public class AddressBookController : Controller
    {
        private readonly AddressBookAppDbContext addressBookDbContext;

        public AddressBookController(AddressBookAppDbContext addressBookDbContext)
        {
            this.addressBookDbContext = addressBookDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAddressViewModel addAddressRequest)
        {
            var address = new Address()
            {
                Id = Guid.NewGuid(),
                FirstName = addAddressRequest.FirstName,
                LastName = addAddressRequest.LastName,
                HomeAddress = addAddressRequest.HomeAddress,
                PhoneNumber = addAddressRequest.PhoneNumber,
                Birthday = addAddressRequest.Birthday


             };
            await addressBookDbContext.Addresses.AddAsync(address);
            await addressBookDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var addresses = await addressBookDbContext.Addresses.ToListAsync();
            return View(addresses);
        }
    }
}
