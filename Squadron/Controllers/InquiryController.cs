using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Squadron.Controllers
{

    public class InquiryController : Controller
    {
        public IActionResult Inquiry()
        {
            return View();
        }
    }
}
