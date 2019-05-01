using System.Collections.Generic;
using CleanItERP.Services;
using CleanItERP.Controllers;
using CleanItERP.DataModel;
using CleanItERPTests.DataModel;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CleanItERPTests.Controllers
{
    public class TextileTypeControllerTest
    {
        [Fact]
        public void GetAllTextileTypesCallsServicesGetBranches()
        {
            var service = Substitute.For<ITextileTypeListService>();
            var controller = new TextileTypeController(service);

            controller.GetAllTextileTypes();

            service.Received().GetTextileTypes();
        }

        [Fact]
        public void GetAllTextileTypesReturnsResultOfServicesGetBranches()
        {
            var service = Substitute.For<ITextileTypeListService>();
            var type = EntityFactory.CreateTextileType();
            var types = new List<TextileType>(){ type };
            service.GetTextileTypes().Returns(types);
            var controller = new TextileTypeController(service);

            var action = controller.GetAllTextileTypes();
            action.Value.Should().Contain(type);
        }

    }
}