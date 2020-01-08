using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
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
        [DefaultValue("")]
        public string LastName {get; set;}

        [StringLength(50)]
        [Required]
        public string Email {get; set;}

        [StringLength(20)]
        [Required]
        public string Password {get; set;}

        [StringLength(20)]
        [Required]
        public string ContactNo {get; set;}

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


    }


    public class UserDto
    {
       [StringLength(50)] 
       public string Id {get; set;}

        [StringLength(50)]
        public string FirstName {get; set;}

        [StringLength(50)]
        public string LastName {get; set;}

        [StringLength(50)]
        public string Email {get; set;}

        [StringLength(20)]
        public string Password {get; set;}

        [StringLength(20)]
        public string ContactNo {get; set;}

    }
}