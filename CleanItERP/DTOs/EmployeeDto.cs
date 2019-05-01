using CleanItERP.DataModel;

namespace CleanItERP.DTOs
{
    public class EmployeeDto
    {
        public int Id {get; set;}
        public int SocialSecurityNumber {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static EmployeeDto CreateFromEmployee(Employee customer){
            return new EmployeeDto(){
                Id = customer.Id,
                SocialSecurityNumber = customer.SocialSecurityNumber,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
    }
}