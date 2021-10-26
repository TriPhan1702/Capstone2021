﻿namespace HairCutAppAPI.DTOs.ComboDTOs
{
    public class AdvancedGetCombosResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdated { get; set; }
    }
}