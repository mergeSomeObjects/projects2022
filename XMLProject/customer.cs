namespace XMLProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [StringLength(9)]
        public string CustomerID { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(100)]
        public string ContactTitle { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string StreetAddress { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Region { get; set; }

        public int? PostalCode { get; set; }

        [StringLength(100)]
        public string Country { get; set; }
    }
}
