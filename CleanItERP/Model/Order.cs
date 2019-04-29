using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanItERP.Model
{
    public class Order
    {
        public int Id {get; set;}

        [Required]
        public string Identifier {get; set;}
        public int BranchId {get; set;}
        public int CustomerId {get; set;}
        public int ClerkId {get; set; }
        
        public DateTime DateReceived {get; set;}
        public DateTime? DateReturned {get; set;}
        public Branch Branch {get; set;}
        public Customer Customer {get; set;}
        public Employee Clerk {get; set;}
        public ICollection<Textile> Textiles { get; set; }

    }
}