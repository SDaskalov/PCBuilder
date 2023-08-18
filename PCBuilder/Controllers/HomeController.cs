namespace PCBuilder.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.Home;
    using PCBuilder.Web.ViewModels.PCConfiguration;

    [Authorize]
    public class HomeController : Controller
    {

        private readonly IPCBuildService pcBuildService;

        public HomeController(IPCBuildService pcBuildService)
        {
            this.pcBuildService = pcBuildService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            
            IEnumerable<PCBuildViewModel> viewModel = await this.pcBuildService.LastFourBuildsAsync();


            return View(viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {            
                return View("Error");
            
        }
    }
}