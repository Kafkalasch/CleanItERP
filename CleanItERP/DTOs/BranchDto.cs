using CleanItERP.DataModel;

namespace CleanItERP.DTOs
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public static BranchDto CreateFromBranch(Branch branch){
            return new BranchDto(){
                Id = branch.Id,
                Name = branch.Name,
                City = branch.City
            };
        }
    }
}