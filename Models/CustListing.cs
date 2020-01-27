using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using NetTopologySuite.Geometries;
namespace Rentless.Models

{
    public class CustListing
    {



        [StringLength(10)]
        public string CustomerId {get; set;}
        public Customer Customer {get; set;}

        public int ProductCode {get; set;}
        public Product Product {get; set;}

        public Point Location {get; set;}

        public double Longtude {get; set;}

        public double Latitude {get; set;}


    }

    public class CustListingView
    {



        [StringLength(10)]
        public string CustomerId {get; set;}
        public Customer Customer {get; set;}

        public int ProductCode {get; set;}
        public Product Product {get; set;}

        public Point Location {get; set;}

        public double Longtude {get; set;}

        public double Latitude {get; set;}



        public double Distance {get; set;}


    }
}