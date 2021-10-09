using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

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
        
        public int Duration { get; set; }
        
        public ICollection<int> Services { get; set; }

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

            if (Duration >=0 && Duration != combo.Duration)
            {
                combo.Duration = Duration;
            }

            return combo;
        }
    }
}