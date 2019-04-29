using System;

namespace CleanItERP.Model
{
    public class Order
    {
        public int Id {get; set;}
        public string Identifier {get; set;}
        public int BranchId {get; set;}
        public int CustomerId {get; set;}
        public int ClerkId {get; set; }
        
        public DateTime DateReceived {get; set;}
        public DateTime DateReturned {get; set;}
        public Branch Branch {get; set;}
        public Customer Customer {get; set;}
        public Employee Clerk {get; set;}
    }
}