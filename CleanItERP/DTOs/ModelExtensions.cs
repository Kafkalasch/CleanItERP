using CleanItERP.DataModel;

namespace CleanItERP.DTOs
{
    public static class ModelExtensions
    {
        public static BranchDto ToDto(this Branch branch) => BranchDto.CreateFromBranch(branch);
        
        public static CustomerDto ToDto(this Customer customer) => CustomerDto.CreateFromCustomer(customer);

        public static EmployeeDto ToDto(this Employee employee) => EmployeeDto.CreateFromEmployee(employee);

        public static TextileDto ToDto(this Textile textile, CleanItERPContext context) => TextileDto.CreateFromTextile(textile, context);

        public static OrderDto ToDto(this Order order, CleanItERPContext context) => OrderDto.CreateFromOrder(order, context);

    }
}