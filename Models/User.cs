using System.ComponentModel.DataAnnotations;
namespace Rentless.Models
{
    public class User
    {
        [StringLength(50)]
        [Key]
        [Required]
        public string Id {get; set;}

        [StringLength(50)]
        [Required]
        public string FirstName {get; set;}

        [StringLength(50)]
        public string LastName {get; set;}

        [StringLength(20)]
        [Required]
        public string Email {get; set;}

        [StringLength(20)]
        [Required]
        public string Password {get; set;}

        [StringLength(20)]
        [Required]
        public string ContactNo {get; set;}


    }
}