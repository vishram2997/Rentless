using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class CustListing
    {



        [Key,  Column(Order = 0)]
        [StringLength(10)]
        public string CustomerCode {get; set;}
        public Customer Customer {get; set;}

        [Key,  Column(Order = 1)]
        public int ProductCoode {get; set;}
        public Product Product {get; set;}
        

    }
}