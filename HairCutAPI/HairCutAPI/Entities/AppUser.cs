using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairCutAPI.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3), MaxLength(100)]
        public string UserName { get; set; }
    }
}
