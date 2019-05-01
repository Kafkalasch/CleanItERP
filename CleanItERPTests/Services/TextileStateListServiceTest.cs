using CleanItERP.Services;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Services
{
    public class TextileStateListServiceTest : ADbContextTest
    {

        [Fact]
        public void ReturnsEmptyListWhenDatabaseIsEmpty(){
            using (var context = CreateContext())
            {
                var service = new TextileStateListService(context);
                var branches = service.GetTextileStates();
                branches.Should().BeEmpty();
            }
        }

        [Fact]
        public void ReturnsAllBranchesInDatabase(){
            var state1Name = "State 1";
            var state2Name = "State 2";

            var state1 = EntityFactory.CreateTextileState();
            state1.Description = state1Name;
            
            var state2 = EntityFactory.CreateTextileState();
            state2.Description = state2Name;

            using(var context = CreateContext()){
                context.Add(state1);
                context.Add(state2);
                context.SaveChanges();
            }

            using (var context = CreateContext())
            {   
                var service = new TextileStateListService(context);
                var branches = service.GetTextileStates();
                branches.Should().HaveCount(2);
                branches.Should().Contain(b => b.Description == state1Name);
                branches.Should().Contain(b => b.Description == state2Name);
            }
        }
        
    }
}