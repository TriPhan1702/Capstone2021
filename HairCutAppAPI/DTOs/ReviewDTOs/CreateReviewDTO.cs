using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.ReviewDTOs
{
    public class CreateReviewDTO
    {
        [Required]
        public int SalonId { get; set; }
        [Required]
        public bool Rating { get; set; }
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Description { get; set; }

        public Review ToNewReview(int customerId)
        {
            return new Review()
            {
                Rating = Rating,
                SalonId = SalonId,
                Description = Description,
                AuthorId = customerId,
                CreatedDate = DateTime.Now,
                LastUpdate = DateTime.Now
            };
        }
    }
}