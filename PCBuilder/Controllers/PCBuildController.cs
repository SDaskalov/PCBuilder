
namespace PCBuilder.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Build.Framework;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.Infrastructure.Extensions;
    using PCBuilder.Web.ViewModels.PCConfiguration;

    [Authorize]
    public class PCBuildController : Controller
    {

        private readonly IBuilderService _builderService;
        private readonly IPCBuildService _pcBuildService;

        public PCBuildController(IBuilderService builderService, IPCBuildService pcBuildService)
        {
            _builderService = builderService;
            _pcBuildService = pcBuildService;
        }


        public async Task<IActionResult> Bid(int id)
        {
            return RedirectToAction("Index","Home");
        }

            [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);


            return View(gpu);
        }
    }
}
