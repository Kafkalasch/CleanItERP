using CleanItERP.Services;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Services
{
    public class ListBranchesServiceTest : ADbContextTest
    {

        [Fact]
        public void ReturnsEmptyListWhenDatabaseIsEmpty(){
            using (var context = CreateContext())
            {
                var service = new ListBranchesService(context);
                var branches = service.GetBranches();
                branches.Should().BeEmpty();
            }
        }

        [Fact]
        public void ReturnsAllBranchesInDatabase(){
            var branch1Name = "Branch 1";
            var branch2Name = "Branch 2";

            var branch1 = EntityFactory.CreateBranch();
            branch1.Name = branch1Name;
            
            var branch2 = EntityFactory.CreateBranch();
            branch2.Name = branch2Name;

            using(var context = CreateContext()){
                context.Add(branch1);
                context.Add(branch2);
                context.SaveChanges();
            }

            using (var context = CreateContext())
            {   
                var service = new ListBranchesService(context);
                var branches = service.GetBranches();
                branches.Should().HaveCount(2);
                branches.Should().Contain(b => b.Name == branch1Name);
                branches.Should().Contain(b => b.Name == branch2Name);
            }
        }
        
    }
}