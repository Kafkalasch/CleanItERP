using System;
using CleanItERP.Model;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Model
{
    public class BranchTest : AModelTest
    {
        [Fact]
        public void TestOrderReverseNavigationOfBranch()
        {
            var branch = EntityFactory.CreateBranch();
            var customer = EntityFactory.CreateCustomer();
            var employee = EntityFactory.CreateEmployee();

            var order = new Order()
            {
                Identifier = "TestOrder1",
                Branch = branch,
                Customer = customer,
                Clerk = employee,
                DateReceived = DateTime.Now,
                DateReturned = DateTime.Now + TimeSpan.FromDays(1)
            };

            using (var context = CreateContext())
            {
                context.Add(order);
                context.SaveChanges();
            }

            branch.Orders.Should().Contain(order);
        }
        
    }
}