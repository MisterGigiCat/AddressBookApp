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

        [HttpGet]

        public async Task<IActionResult> View(Guid id)
        {
            var address = await addressBookDbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);

            if(address != null)
            {
                var viewModel = new EditAddressViewModel()
                {
                    Id= address.Id,
                    FirstName = address.FirstName,
                    LastName= address.LastName,
                    HomeAddress= address.HomeAddress,   
                    PhoneNumber= address.PhoneNumber,   
                    Birthday= address.Birthday
                };
                return await Task.Run(()=> View("View",viewModel)) ;
            }
            return RedirectToAction("Index");
        }




        [HttpPost]

        public async Task<IActionResult> View(EditAddressViewModel model)
        {
            var address = await addressBookDbContext.Addresses.FindAsync(model.Id);

            if (address != null)
            {
                address.FirstName = model.FirstName;
                address.LastName = model.LastName;
                address.HomeAddress = model.HomeAddress;
                address.PhoneNumber = model.PhoneNumber;
                address.Birthday = model.Birthday;

                await addressBookDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
    
}
