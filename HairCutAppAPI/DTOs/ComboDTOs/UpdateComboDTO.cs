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
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        public IFormFile AvatarFile { get; set; }
        
        public ICollection<CreateUpdateComboDetailDTO> Details { get; set; }

        /// <summary>
        /// Find out the difference and update the different field to entity  
        /// </summary>
        public Combo CompareUpdateCombo(Combo combo, string avatarUrl = null)
        {
            var hasChanged = false;
            if (!string.IsNullOrWhiteSpace(Name) && Name != combo.Name)
            {
                combo.Name = Name;
                hasChanged = true;
            }
            if (!string.IsNullOrWhiteSpace(Description) && Description != combo.Description)
            {
                combo.Description = Description;
                hasChanged = true;
            }
            if (!string.IsNullOrWhiteSpace(Status) && Status != combo.Status)
            {
                combo.Status = Status.ToLower();
                hasChanged = true;
            }

            if (Price >=0 && Price != combo.Price)
            {
                combo.Price = Price;
                hasChanged = true;
            }

            if (avatarUrl != null)
            {
                combo.AvatarUrl = avatarUrl;
                hasChanged = true;
            }

            if (!hasChanged)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Không có gì thay đổi, dựa vào thông tin từ request");
            }

            return combo;
        }
    }
}