using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairCutAppAPI.DTOs.ReviewDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public bool Rating { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        
        // [Required]
        // public DateTime LastUpdate { get; set; }
        
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Customer Author { get; set; }

        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public virtual Salon Salon { get; set; }
        
        public ReviewDTO ToReviewDTO()
        {
            return new ReviewDTO()
            {
                Id = Id,
                CustomerId = Author.Id,
                CustomerUserId = Author.UserId,
                SalonId = SalonId,
                Description = Description,
                Rating = Rating,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                CustomerName = Author.FullName,
                SalonName = Salon.Name
            };
        }

        public ReviewDTO ToReviewDTO(Salon salon, Customer customer, int userId)
        {
            return new ReviewDTO()
            {
                Id = Id,
                CustomerId = customer.Id,
                CustomerUserId = userId,
                SalonId = SalonId,
                Description = Description,
                Rating = Rating,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                CustomerName = customer.FullName,
                SalonName = salon.Name
            };
        }
    }
}