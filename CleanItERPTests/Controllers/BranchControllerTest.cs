using System.Collections.Generic;
using CleanItERP.Services;
using CleanItERP.Controllers;
using CleanItERP.DataModel;
using CleanItERPTests.DataModel;
using FluentAssertions;
using NSubstitute;
using Xunit;
using CleanItERP.DTOs;

namespace CleanItERPTests.Controllers
{
    public class BranchControllerTest
    {
        [Fact]
        public void GetAllBranchesCallsServicesGetBranches()
        {
            var service = Substitute.For<IBranchListService>();
            var controller = new BranchController(service);

            controller.GetAllBranches();

            service.Received().GetBranches();
        }

        [Fact]
        public void GetAllBranchesReturnsResultOfServicesGetBranches()
        {
            var service = Substitute.For<IBranchListService>();
            var branch = EntityFactory.CreateBranch().ToDto();
            var branches = new List<BranchDto>(){ branch };
            service.GetBranches().Returns(branches);
            var controller = new BranchController(service);

            var allBranchesAction = controller.GetAllBranches();
            allBranchesAction.Value.Should().Contain(branch);
        }

    }
}