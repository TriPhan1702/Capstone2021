using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.ComboDTOs
{
    public class CreateComboDTO
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public int Duration { get; set; }
        
        public ICollection<int> Services { get; set;}

        public Combo ToNewCombo()
        {
            
            return new Combo()
            {
                Name = Name,
                Description = Description,
                Duration = Duration,
                Status = Status.ToLower(),
            };
        }
    }
}