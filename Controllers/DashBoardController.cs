using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegLog.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
       
        public IActionResult Display()
        {
            return View();
        }

    }
}
