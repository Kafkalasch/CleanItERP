using System;
using System.Collections.Generic;
namespace CleanItERP.DTOs
{
    public class OrderDto
    {
        public int Id {get; set;}
        public string Identifier {get; set;}
        public DateTime DateReceived {get; set;}
        public DateTime? DateReturned {get; set;}
        public string Branch {get; set;}
        public CustomerDto Customer {get; set;}
        public EmployeeDto Clerk {get; set;}
        public ICollection<TextileDto> Textiles { get; set; }
    }
}