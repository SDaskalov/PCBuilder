namespace PCBuilder.Tests
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Services;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.PCConfiguration;

    public class BuilderServiceTests
    {

        private DbContextOptions<PCBuilderDbContext> dbOptions;
        private PCBuilderDbContext dbContext;

        private IComputerCaseService _caseService;
        private IBuilderService _builderService;
        private ICPUService _cpuService;
        private IMotherBoardService _motherBoardService;
        private IGPUService _gpusService;
        private ISocketCategoryService _socketCategoryService;
        private IVendorCategoryService _vendorCategoryService;
        private IPCBuildService _pcbuildService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<PCBuilderDbContext>()
                .UseInMemoryDatabase("PCBuilderInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new PCBuilderDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();


            this._builderService = new BuilderService(this.dbContext);
            this._caseService = new ComputerCaseService(this.dbContext);
            this._cpuService = new CPUService(this.dbContext);
            this._motherBoardService = new MotherBoardService(this.dbContext);
            this._gpusService = new GPUService(this.dbContext);
            this._socketCategoryService = new SocketCategoryService(this.dbContext);
            this._vendorCategoryService = new VendorCategoriesService(this.dbContext);
            this._pcbuildService = new PCBuildService(this.dbContext);


        }




        [Test]
        public async Task BuilderNameIsTakeShouldReturnFalse()
        {
            string name = "SEEEDBUILDER NAME";

            bool res = await this._builderService.BuilderNameIsTaken(name);

            Assert.IsTrue(res);
        }

        [Test]
        public async Task BuilderIdByUserIdShouldReturnCorrectId()
        {

            string buildId = "7131367d-d5ad-4f72-b6f7-703bca071854";

            string? test = await this._builderService.BuilderIdByUserId(buildId);
            bool asnwer = false;
            if (test != null)
            {
                asnwer = test.ToLower() == buildId.ToLower();

            }

            Assert.IsTrue(asnwer);

        }

        [Test]
        public async Task BuilderAlreadyExistsCorrectResponse()
        {

            string buildId = "7131367d-d5ad-4f72-b6f7-703bca071854";

            bool res = await this._builderService.BuilderAlreadyExcistsByUserId(buildId);

            Assert.IsTrue(res);

        }

        [Test]
        public async Task CaseExistsByModelName()
        {

            string caseName = "Fractal Design North";

            bool res = await this._caseService.CaseExistsByModelName(caseName);

            Assert.IsTrue(res);

        }
        [Test]
        public async Task CaseGetDetailsReturnsCorrectPrice()
        {

            decimal casePrice = 180M;

            var res = await this._caseService.GetCaseDetailsAsync(1);

            bool answer = false;
            if (res != null)
            {
                answer = res.Price == casePrice;
            }


            Assert.IsTrue(answer);

        }
        [Test]
        public async Task CaseByIdAsyncReturnsCorrectId()
        {

            int id = 2;

            var res = await this._caseService.GetCaseByIdAsync(id);
            string expectedName = "Lian Li Lancool 216";

            bool answer = false;
            if (res != null)
            {
                answer = res.ModelName == expectedName;
            }

            Assert.IsTrue(answer);

        }

        [Test]
        public async Task GetAllAsyncCasesReturnsCorrectAmount()
        {

            int expected = 3;

            var res = await this._caseService.GetAllAsync();

            Assert.IsTrue(res.Count() == expected);

        }

        [Test]
        public async Task CPUExistsByModelNameCorrectResponse()
        {

            int expected = 4;
            var res = await this._cpuService.GetAllAsync();

            Assert.IsTrue(res.Count() == expected);

        }
        [Test]
        public async Task CPUExistsByModelName()
        {

            string caseName = "Intel Core i9-11900KF";

            bool res = await this._cpuService.CPUExistsByModelName(caseName);

            Assert.IsTrue(res);

        }
        [Test]
        public async Task GetAllCPUCategoriesCorrectResponse()
        {

            int expected = 4;
            var res = await this._cpuService.GetAllCPUCategoriesAsync();

            Assert.IsTrue(res.Count() == expected);

        }



        [Test]
        public async Task CPUDetailsByIdCorrectResult()
        {

            int id = 2;

            var res = await this._cpuService.GetCPUDetailsAsync(id);
            string expectedName = "Ryzen 7 7700x";

            bool answer = false;
            if (res != null)
            {
                answer = res.ModelName == expectedName;
            }

            Assert.IsTrue(answer);

        }
        [Test]
        public async Task CPUByIdCorrectResult()
        {

            int id = 2;

            var res = await this._cpuService.GetCPUByIdAsync(id);
            string expectedName = "Ryzen 7 7700x";

            bool answer = false;
            if (res != null)
            {
                answer = res.ModelName == expectedName;
            }

            Assert.IsTrue(answer);

        }

        [Test]
        public async Task GetAllGPUsCorrectResponse()
        {

            int expected = 4;
            var res = await this._gpusService.GetAllAsync();

            Assert.IsTrue(res.Count() == expected);

        }
        [Test]
        public async Task GPUExistsByModelName()
        {

            string caseName = "AMD RX 7900XTX";

            bool res = await this._gpusService.GPUExistsByModelName(caseName);

            Assert.IsTrue(res);

        }


        [Test]
        public async Task GPUDetailsByIdCorrectResult()
        {

            int id = 4;

            var res = await this._gpusService.GetGPUByIdAsync(id);
            string expectedName = "AMD RX 6950XT";

            bool answer = false;
            if (res != null)
            {
                answer = res.ModelName == expectedName;
            }

            Assert.IsTrue(answer);

        }
        [Test]
        public async Task GPUByIdCorrectResult()
        {

            int id = 2;

            var res = await this._gpusService.GetGPUDetailsAsync(id);
            string expectedName = "GeForce RTX 4090";

            bool answer = false;
            if (res != null)
            {
                answer = res.ModelName == expectedName;
            }

            Assert.IsTrue(answer);

        }

        [Test]
        public async Task GetAllMBsCorrectResponse()
        {

            int expected = 6;
            var res = await this._motherBoardService.GetAllAsync();

            Assert.IsTrue(res.Count() == expected);

        }
        [Test]
        public async Task MBExistsByModelName()
        {

            string caseName = "Gigabyte Motherboard Z790 AORUS ELITE AX";

            bool res = await this._motherBoardService.MBExistsByModelName(caseName);

            Assert.IsTrue(res);

        }


        [Test]
        public async Task MBDetailsByIdCorrectResult()
        {

            int id = 4;

            var res = await this._motherBoardService.GetMBDetailsAsync(id);
            string expectedName = "MSI MAG B550 Tomahawk";

            bool answer = false;
            if (res != null)
            {
                answer = res.Name == expectedName;
            }

            Assert.IsTrue(answer);

        }
        [Test]
        public async Task MBByIdCorrectResult()
        {

            int id = 2;

            var res = await this._motherBoardService.GetMBByIdAsync(id);
            decimal expectedName = 228.99M;

            bool answer = false;
            if (res != null)
            {
                answer = res.Price == expectedName;
            }

            Assert.IsTrue(answer);

        }
        [Test]
        public async Task GetAllSocketCategoriesResponse()
        {

            int expected = 4;
            var res = await this._socketCategoryService.GetAllSocketCategoriesAsync();

            Assert.IsTrue(res.Count() == expected);

        }
        [Test]
        public async Task SocketExistsById()
        {
            int id = 2;
            bool res = await this._socketCategoryService.SocketExistsById(id);

            Assert.IsTrue(res);

        }
        [Test]
        public async Task GetAllVendorCategoriesResponse()
        {

            int expected = 2;
            var res = await this._vendorCategoryService.GetAllVendorCategoriesAsync();

            Assert.IsTrue(res.Count() == expected);

        }
        [Test]
        public async Task VendorExistsById()
        {
            int id = 2;
            bool res = await this._socketCategoryService.SocketExistsById(id);

            Assert.IsTrue(res);

        }

        [Test]
        public async Task GetPCDetailsForAdminAsyncCorrectDetails()
        {
            int id = 1;
            var res = await this._pcbuildService.GetPCDetailsForAdminAsync(id);
            bool correctType = false;
            if (res != null)
            {
                correctType = res.GetType().Name == typeof(PCBuildDetailsViewModel).Name;

            }

            Assert.IsTrue(correctType);

        }

        [Test]
        public async Task CheckIfPCExistsReturnsCorrectResponse()
        {
            int id = 1;
            var res = await this._pcbuildService.CheckifPCExistsByIdAsync(id);



            Assert.IsTrue(res);

        }

        [Test]
        public async Task CheckIfPCExistsForAdminReturnsCorrectResponse()
        {
            int id = 1;
            var res = await this._pcbuildService.CheckifPCExistsByIdForAdminAsync(id);
            Assert.IsTrue(res);

        }
        [Test]
        public async Task CheckIfOwnedPCExistsForAdminReturnsCorrectResponse()
        {
            int id = 1;
            var res = await this._pcbuildService.CheckifOwnedPCExistsByIdAsync(id);
            Assert.IsFalse(res);

        }

        [Test]
        public async Task GetAllPCReturnsCorrectAmount()
        {

            int expected = 1;
            var res = await this._pcbuildService.AllBuildsAsync();

            Assert.IsTrue(res.Count() == expected);

        }

        [Test]
        public async Task GetLast4PCReturnsCorrectAmount()
        {

            int expected = 4;
            var res = await this._pcbuildService.LastFourBuildsAsync();

            Assert.IsFalse(res.Count() == expected);

        }
        [Test]
        public async Task DisablePCSetsDeletedToTrue()
        {

            int id = 1;
            await this._pcbuildService.DisablePcAsync(id);
            var res = await this._pcbuildService.GetPCDetailsForAdminAsync(id);

            bool ans = false;
            if (res != null && res.isDeleted == true)
            {
                ans = true;
            }
            Assert.IsTrue(ans);

        }

        [Test]
        public async Task EnablePCSetsDeletedToFalse()
        {

            int id = 1;
            await this._pcbuildService.DisablePcAsync(id);

            await this._pcbuildService.EnablePcAsync(id);
            var res = await this._pcbuildService.GetPCDetailsForAdminAsync(id);

            bool ans = false;
            if (res != null && res.isDeleted == false)
            {
                ans = true;
            }
            Assert.IsTrue(ans);

        }


        [Test]
        public async Task GetAllBuildsForAdminReturnsCorrectAmount()
        {

            int expected = 1;
            var res = await this._pcbuildService.AllBuildsForAdminAsync();

            Assert.IsTrue(res.Count() == expected);

        }
        [Test]
        public async Task GetDetailsReturnsCorrectPD()
        {

            int expected = 1;
            var res = await this._pcbuildService.GetPCDetailsAsync(expected);
            bool endResult=false;
            if(res != null)
            {
                endResult = res.Name == "Gaming PC 1";
            }


            Assert.IsTrue(endResult);

        }

        [Test]
        public async Task GetOwnedPCCorrectAmount()
        {
            string id = "7131367D-D5AD-4F72-B6F7-703BCA071854".ToLower();
            int expected = 0;
            var res = await this._pcbuildService.AllOwnedBuildsAsync(id);

            Assert.IsTrue(res.Count() == expected);

        }

        [Test]
        public async Task SellPCSetsSoldtoTrue()
        {
            string id = "7131367D-D5AD-4F72-B6F7-703BCA071854".ToLower();
            int pcid = 1;
            await this._pcbuildService.SellPcAsync(pcid,id);
            var res = await this._pcbuildService.CheckifOwnedPCExistsByIdAsync(pcid);
            Assert.IsTrue(res);

        }


    }

}

