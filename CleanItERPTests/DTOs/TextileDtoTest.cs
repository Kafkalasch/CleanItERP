using System.Linq;
using CleanItERP.DTOs;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DTOs
{
    public class TextileDtoTest : ADbContextTest
    {
        [Fact]
        public void MapsPropsProperlyWithLoadedNavigationProps(){
            var textile = EntityFactory.CreateTextile();
            var textileDto = textile.ToDto(null);
            textileDto.Id.Should().Be(textile.Id);
            textileDto.Identifier.Should().Be(textile.Identifier);
            textileDto.TextileType.Should().Be(textile.TextileType.Description);
            textileDto.TextileState.Should().Be(textile.TextileState.Description);
        }

        [Fact]
        public void MapsPropsProperlyWithoutLoadedNavigationProps(){
            var textile = EntityFactory.CreateTextile();

            using(var context = CreateContext()){
                context.Add(textile);
                context.SaveChanges();
            }


            using(var context = CreateContext()){
                var textileWithoutNavs = context.Textiles.Single();

                textileWithoutNavs.TextileState.Should().BeNull();
                textileWithoutNavs.TextileType.Should().BeNull();

                var textileDto = textileWithoutNavs.ToDto(context);
                textileDto.Id.Should().Be(textile.Id);
                textileDto.Identifier.Should().Be(textile.Identifier);
                textileDto.TextileType.Should().Be(textile.TextileType.Description);
                textileDto.TextileState.Should().Be(textile.TextileState.Description);
            }
        }
    }
}