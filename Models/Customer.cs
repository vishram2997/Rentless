using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace Rentless.Models
{
    public class Customer
    {
        [StringLength(20)]
        [Key]
        [Required]
        public string Id {get; set;}

        [StringLength(50)]
        [Required]
        public string FirstName {get; set;}

        [StringLength(50)]
        public string LastName {get; set;}

        [StringLength(50)]
        [Required]
        public string Email {get; set;}

        public VerificationStatus VerificationStatus {get; set;}

        [StringLength(50)]
        [Required]
        public string ContactNo {get; set;}



    }
}