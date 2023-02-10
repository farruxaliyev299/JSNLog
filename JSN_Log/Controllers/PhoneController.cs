using JSN_Log.Models;
using Microsoft.AspNetCore.Mvc;
using JSNLog;

namespace JSN_Log.Controllers
{
    public class PhoneController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        private List<Phone> phones = new List<Phone>()
        {
            new Phone(){ Id=1, Brand = "Samsung", Model = "Galaxy S23 Ultra"},
            new Phone(){ Id=2, Brand = "Samsung", Model = "Galaxy S23"},
            new Phone(){ Id=3, Brand = "IPhone", Model = "14 Pro Max"},
            new Phone(){ Id=4, Brand = "IPhone", Model = "14 Pro"},
            new Phone(){ Id=5, Brand = "IPhone", Model = "14"},
            new Phone(){ Id=6, Brand = "Xiaomi", Model = "MI 9"},
            new Phone(){ Id=7, Brand = "Google", Model = "Pixel 7"},
        };

        public PhoneController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(phones);
        }

        public IActionResult GetAll()
        {
            _logger.LogDebug("GetAll action is executing...");
            _logger.LogInformation("Getting all phone datas. Datas: {0}", phones.Count());
            return Json(phones);
        }

        public IActionResult GetById(int id)
        {
            _logger.LogDebug("GetById action is executing...");
            var existingPhone = phones.FirstOrDefault(phone => phone.Id == id);

            if(existingPhone == null)
                _logger.LogError("Can not get phone data by id! Id: {0}", id);
            else
                _logger.LogInformation("Getting phone data by id. Id: {0}", id);

            return Json(existingPhone);
        }
    }
}
