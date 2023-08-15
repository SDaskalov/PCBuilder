namespace PCBuilder.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    [Authorize]
    public class BuilderController : Controller
    {
        public async Task<IActionResult> Index()
        {
             return  View();
        }
    }
}
