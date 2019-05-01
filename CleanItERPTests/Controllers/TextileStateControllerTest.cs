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
    public class TextileStateControllerTest
    {
        [Fact]
        public void GetAllTextileStatesCallsServicesGetBranches()
        {
            var service = Substitute.For<ITextileStateListService>();
            var controller = new TextileStateController(service);

            controller.GetAllTextileStates();

            service.Received().GetTextileStates();
        }

        [Fact]
        public void GetAllTextileStatesReturnsResultOfServicesGetBranches()
        {
            var service = Substitute.For<ITextileStateListService>();
            var state = EntityFactory.CreateTextileState();
            var states = new List<TextileState>(){ state };
            service.GetTextileStates().Returns(states);
            var controller = new TextileStateController(service);

            var action = controller.GetAllTextileStates();
            action.Value.Should().Contain(state);
        }

    }
}