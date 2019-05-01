using CleanItERP.DTOs;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DTOs
{
    public class BranchDtoTest
    {
        [Fact]
        public void CreateFromBranchMapsPropsProperly(){
            var branch = EntityFactory.CreateBranch();
            var branchDto = branch.ToDto();
            branchDto.Id.Should().Be(branch.Id);
            branchDto.Name.Should().Be(branch.Name);
            branchDto.City.Should().Be(branch.City);
        }
    }
}