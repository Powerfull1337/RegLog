using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegLog.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        
        public IActionResult Display()
        {
            return View();
        }

        
        
    }
}
