
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
    using static PCBuilder.Web.Infrastructure.Extensions.ClaimsPrincipalExtensions;

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

            //bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            //if (!isBuilder)
            //{
            //    this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
            //    return this.RedirectToAction("Become", "Builder");
            //}
            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);

            if (gpu != null)
            {
                if (gpu.HighestBidderId == Guid.Parse(this.User.GetId()!))
                {
                    this.TempData["ErrorMessage"] = "You already hold the highest bid!";
                }
                else
                {
                    await this._pcBuildService.BidForPcAsync(id, this.User.GetId()!);
                    this.TempData["SuccessMessage"] = "Congratulations! You hold the current highest bid!";

                }
            }

            gpu = await _pcBuildService.GetPCDetailsAsync(id);
            int helper = id;
            // return View("Details", gpu);
            return RedirectToAction("Details", "PCBuild", new { id = helper });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);


            return View(gpu);
        }
    }
}
