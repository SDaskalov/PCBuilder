using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.Contracts;
using PCBuilder.Web.Infrastructure.Extensions;
using PCBuilder.Web.ViewModels.PCConfiguration;

namespace PCBuilder.Areas.Admin.Controllers
{
    public class PCBuildController : BaseAdminController
    {
        private readonly IBuilderService _builderService;
        private readonly IPCBuildService _pcBuildService;
        private readonly ICPUService _cpusService;
        private readonly IGPUService _gpusService;
        private readonly IComputerCaseService _computerCaseService;
        private readonly IMotherBoardService _motherBoardService;

        public PCBuildController(IBuilderService builderService, IPCBuildService pCBuildService, ICPUService cPUService, IGPUService gPUService, IComputerCaseService computerCaseService, IMotherBoardService motherBoardService)
        {
            this._builderService = builderService;
            this._pcBuildService = pCBuildService;
            this._cpusService = cPUService;
            this._gpusService = gPUService;
            this._computerCaseService = computerCaseService;
            this._motherBoardService = motherBoardService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var check = await _pcBuildService.CheckifPCExistsByIdForAdminAsync(id);

            if (!check)
            {
                return RedirectToAction("Index", "Admin/Home");
            }

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsForAdminAsync(id);


            return View(gpu);
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
            IEnumerable<PCBuildDetailsViewModel> pcs = await this._pcBuildService.AllBuildsForAdminAsync();

            return View(pcs);

        }

        public async Task<IActionResult> Delete(int id)
        {

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);


            if (gpu != null)
            {
                var builderGuid = await this._builderService.BuilderIdByUserId(User.GetId()!);

                if (builderGuid == null || this.User.IsAdmin() == false)
                {
                    this.TempData["ErrorMessage"] = "You do not have rights to delete!";
                }

            }
            if (this.User.IsAdmin())
            {
                await this._pcBuildService.DisablePcAsync(id);
                this.TempData["SuccessMessage"] = "You deleted the PC!";
            }

            return RedirectToAction("All", "PCBuild");
        }

        public async Task<IActionResult> Restore(int id)
        {

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsForAdminAsync(id);


            if (gpu != null)
            {
                var builderGuid = await this._builderService.BuilderIdByUserId(User.GetId()!);

                if (builderGuid == null || this.User.IsAdmin() == false)
                {

                    this.TempData["ErrorMessage"] = "You do not have rights to restore!";

                }
            }
            if (this.User.IsAdmin())
            {
                await this._pcBuildService.EnablePcAsync(id);
                this.TempData["SuccessMessage"] = "You restored the PC!";
            }

            gpu = await _pcBuildService.GetPCDetailsAsync(id);
            int helper = id;

            return RedirectToAction("Details", "PCBuild", new { id = helper });
        }


        public async Task<IActionResult> Sell(int id)
        {

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);


            if (gpu != null)
            {
                if (this.User.IsAdmin())
                {
                    await this._pcBuildService.SellPcAsync(id, this.User.GetId()!);
                    this.TempData["SuccessMessage"] = "Congratulations! You sold the PC!";
                }
            }


            gpu = await _pcBuildService.GetPCDetailsAsync(id);
            int helper = id;

            return RedirectToAction("Details", "PCBuild", new { id = helper });
        }




    }
}
