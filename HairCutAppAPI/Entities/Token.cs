using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public AppUser User { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Type { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public string TokenValue { get; set; }
        
        public DateTime ExpirationDate { get; set; }
    }
}