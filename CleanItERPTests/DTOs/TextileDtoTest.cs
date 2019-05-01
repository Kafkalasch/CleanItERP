using System.Linq;
using CleanItERP.DataModel;
using CleanItERP.DTOs;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DTOs
{
    public class TextileDtoTest : ADbContextTest
    {
        [Fact]
        public void MapsPropsProperlyWithLoadedNavigationProps()
        {
            var textileWithNavs = EntityFactory.CreateTextile();
            var textileDto = textileWithNavs.ToDto(null);

            AssertProperlyMappedProps(textileDto, textileWithNavs);
        }


        [Fact]
        public void MapsPropsProperlyWithoutLoadedNavigationProps(){
            var textileWithNavs = EntityFactory.CreateTextile();

            using(var context = CreateContext()){
                context.Add(textileWithNavs);
                context.SaveChanges();
            }


            using(var context = CreateContext()){
                var textileWithoutNavs = context.Textiles.Single();

                textileWithoutNavs.TextileState.Should().BeNull();
                textileWithoutNavs.TextileType.Should().BeNull();

                var textileDto = textileWithoutNavs.ToDto(context);
                textileDto.Id.Should().Be(textileWithNavs.Id);

                AssertProperlyMappedProps(textileDto, textileWithNavs);
            }
        }

        private static void AssertProperlyMappedProps(TextileDto textileDto, Textile textileWithNavigations)
        {
            textileDto.Id.Should().Be(textileWithNavigations.Id);
            textileDto.Identifier.Should().Be(textileWithNavigations.Identifier);
            textileDto.TextileType.Should().Be(textileWithNavigations.TextileType.Description);
            textileDto.TextileState.Should().Be(textileWithNavigations.TextileState.Description);
        }
    }
}