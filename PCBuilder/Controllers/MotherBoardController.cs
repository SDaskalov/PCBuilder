using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.Contracts;
using PCBuilder.Web.Infrastructure.Extensions;
using PCBuilder.Web.ViewModels.CPU;
using PCBuilder.Web.ViewModels.Motherboard;

namespace PCBuilder.Controllers
{
        [Authorize]
    public class MotherBoardController : Controller
    {

        private readonly IMotherBoardService _mbService;
        private readonly IBuilderService _builderService;

        public MotherBoardController(IMotherBoardService mbService, IBuilderService builderService)
        {
            _mbService = mbService;
            _builderService = builderService;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }
            IEnumerable<MBFormViewModel> mbs = await _mbService.GetAllAsync();

            return View(mbs);


        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }
            MBDetailsViewModel? mb = await _mbService.GetMBDetailsAsync(id);

            return View(mb);


        }



    }
}
