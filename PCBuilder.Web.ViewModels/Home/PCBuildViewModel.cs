using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Web.ViewModels.Home
{
    public class PCBuildViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string HighestBid { get; set; } = null!;

        public string Cpu { get; set; } = null!;

        public string Gpu { get; set; } = null!;

        public string Motherboard { get; set; } = null!;

        public string Ram { get; set; } = null!;
    }
}
