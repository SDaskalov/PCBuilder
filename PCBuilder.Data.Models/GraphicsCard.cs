﻿namespace PCBuilder.Data.Models
{
    using System.ComponentModel.DataAnnotations;

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
