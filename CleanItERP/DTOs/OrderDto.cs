using System.Linq;
using System;
using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime? DateReturned { get; set; }
        public BranchDto Branch { get; set; }
        public CustomerDto Customer { get; set; }
        public EmployeeDto Clerk { get; set; }
        public IEnumerable<TextileDto> Textiles { get; set; }

        public static OrderDto CreateFromOrder(Order order, CleanItERPContext context)
        {
            var dto = new OrderDto(){
                Id = order.Id,
                Identifier = order.Identifier,
                DateReceived = order.DateReceived,
                DateReturned = order.DateReturned,
                Branch = ExtractBranchDto(order, context),
                Customer = ExtractCustomerDto(order, context),
                Clerk = ExtractEmployeeDto(order, context),
                Textiles = ExtractTextileDtos(order, context)
            };
            return dto;
        }

        private static BranchDto ExtractBranchDto(Order order, CleanItERPContext context)
        {
            BranchDto branchDto;
            if (order.Branch != null)
            {
                branchDto = order.Branch.ToDto();
            }
            else
            {
                var branch = context.Branches.Find(order.BranchId);
                branchDto = branch.ToDto();
            }

            return branchDto;
        }

        private static CustomerDto ExtractCustomerDto(Order order, CleanItERPContext context)
        {
            CustomerDto customerDto;
            if (order.Customer != null)
            {
                customerDto = order.Customer.ToDto();
            }
            else
            {
                var customer = context.Customers.Find(order.CustomerId);
                customerDto = customer.ToDto();
            }

            return customerDto;
        }

        private static EmployeeDto ExtractEmployeeDto(Order order, CleanItERPContext context)
        {
            EmployeeDto employeeDto;
            if (order.Clerk != null)
            {
                employeeDto = order.Clerk.ToDto();
            }
            else
            {
                var clerk = context.Employees.Find(order.ClerkId);
                employeeDto = clerk.ToDto();
            }

            return employeeDto;
        }

        private static IEnumerable<TextileDto> ExtractTextileDtos(Order order, CleanItERPContext context)
        {
            IList<TextileDto> textileDtos = new List<TextileDto>();
            IEnumerable<Textile> textiles;
            if (order.Textiles != null)
            {
                textiles = order.Textiles.ToList();
            }
            else
            {
                textiles = context.Textiles.Where(t => t.OrderId == order.Id).ToList();
            }
            
            foreach(var textile in textiles){
                textileDtos.Add(textile.ToDto(context));
            }

            return textileDtos;
        }
    }
}