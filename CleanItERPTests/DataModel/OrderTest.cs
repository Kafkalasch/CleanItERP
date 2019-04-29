using System;
using CleanItERP.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DataModel
{
    public class OrderTest : ADbContextTest
    {
        [Fact]
        public void TestBranchNavigationOfOrder()
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

            branch.Id.Should().BeAutoGeneratedId();
            order.BranchId.Should().Be(branch.Id);
        }



        [Fact]
        public void TestCustomerNavigationOfOrder()
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

            customer.Id.Should().BeAutoGeneratedId();
            order.CustomerId.Should().Be(customer.Id);
        }


        [Fact]
        public void TestClerkNavigationOfOrder()
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

            employee.Id.Should().BeAutoGeneratedId();
            order.ClerkId.Should().Be(employee.Id);
        }

        [Fact]
        public void TestTextileReverseNavigationOfTextileOfOrder()
        {
            var type = EntityFactory.CreateTextileType();
            var state = EntityFactory.CreateTextileState();
            var order = EntityFactory.CreateOrder();

            var textile = new Textile()
            {
                Identifier = "J523",
                TextileType = type,
                TextileState = state,
                Order = order
            };

            using (var context = CreateContext())
            {
                context.Add(textile);
                context.SaveChanges();
            }

            order.Textiles.Should().Contain(textile);
        }

        [Fact]
        public void SavingWithoutIdentifierThrows()
        {
            var order = EntityFactory.CreateOrder();
            order.Identifier = null;

            using (var context = CreateContext())
            {
                context.Add(order);
                SavingContextShouldThrowNotNullConstrainedFailedException(context);
            }
        }

    }
}