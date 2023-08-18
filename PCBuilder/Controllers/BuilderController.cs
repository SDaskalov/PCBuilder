namespace PCBuilder.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.Infrastructure.Extensions;
    using PCBuilder.Web.ViewModels.Builder;
    using System.Security.Claims;
    using static PCBuilder.Common.NotificationMessagesConstants;

    [Authorize]
    public class BuilderController : Controller
    {
        private readonly IBuilderService builderService;

        public BuilderController(IBuilderService builderService)
        {
            this.builderService = builderService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {

            string? userId = this.User.GetId();

            bool isAlreadyBuilder = await this.builderService.BuilderAlreadyExcistsByUserId(userId!);
            if (isAlreadyBuilder)
            {
                TempData[ErrorMessage] = "You are already a builder!";

                //return View();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Become(BecomeBuilderFormModel model)
        {
            string? userId = this.User.GetId();

            bool isAlreadyBuilder = await this.builderService.BuilderAlreadyExcistsByUserId(userId!);
            if (isAlreadyBuilder)
            {
                TempData[ErrorMessage] = "You are already a builder!";

                //return View();
                return RedirectToAction("Index", "Home");
            }

            bool isNameTaken = await this.builderService.BuilderNameIsTaken(model.PublicBuilderName);
            if (isNameTaken)
            {
                TempData[ErrorMessage] = "The name is already taken!";

                ModelState.AddModelError(userId!, "This name is already taken. Please try a different one!");
                //return View();              
            }

            if (!ModelState.IsValid)
            {
                return View(model);

            }

            try
            {

                await builderService.Create(userId!, model);
                TempData[SuccessMessage] = "Congartualtions! You are now a builder.";
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected Error!";
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
