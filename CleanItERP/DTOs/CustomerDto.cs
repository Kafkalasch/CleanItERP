using System.Linq.Expressions;
using CleanItERP.DataModel;

namespace CleanItERP.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public int MemberShipId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public static CustomerDto CreateFromCustomer(Customer customer){
            return new CustomerDto(){
                Id = customer.Id,
                MemberShipId = customer.MemberShipId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
    }
}