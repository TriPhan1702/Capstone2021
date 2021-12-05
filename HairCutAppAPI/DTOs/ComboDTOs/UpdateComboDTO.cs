using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.DTOs.ComboDTOs
{
    public class UpdateComboDTO
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public long Price { get; set; }
        
        // public IFormFile AvatarFile { get; set; }
        
        public ICollection<CreateUpdateComboDetailDTO> Details { get; set; }

        /// <summary>
        /// Find out the difference and update the different field to entity  
        /// </summary>
        public Combo CompareUpdateCombo(Combo combo)
        {
            if (!string.IsNullOrWhiteSpace(Name) && Name != combo.Name)
            {
                combo.Name = Name;
            }
            if (!string.IsNullOrWhiteSpace(Description) && Description != combo.Description)
            {
                combo.Description = Description;
            }
            if (!string.IsNullOrWhiteSpace(Status) && Status != combo.Status)
            {
                combo.Status = Status.ToLower();
            }

            if (Price >=0 && Price != combo.Price)
            {
                combo.Price = Price;
            }

            return combo;
        }
    }
}