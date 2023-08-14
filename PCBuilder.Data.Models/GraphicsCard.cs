using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Data.Models
{
	public class GraphicsCard
	{
		[Key]
        public int Id { get; set; }

		[Required]
		public string ModelName { get; set; } = null!;

		[Required]	
        public int MaxWattage { get; set; }

    }
}
