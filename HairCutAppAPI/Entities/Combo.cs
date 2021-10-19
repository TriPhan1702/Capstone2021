using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.DTOs.ComboDTOs;

namespace HairCutAppAPI.Entities
{
    public class Combo
    {
        [Key]
        public int Id { get; set; }
        
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
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        
        //Many-Many
        public ICollection<ComboDetail> ComboDetails { get; set; }
        
        public ICollection<Appointment> Appointments { get; set;}

        public ComboDTO ToComboDTO()
        {
            return new ComboDTO()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                Status = Status
            };
        }

        public UpdateComboResponseDTO ToUpdateComboResponseDTO()
        {
            return new UpdateComboResponseDTO()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Duration = Duration,
                Status = Status,
            };
        }
    }
}