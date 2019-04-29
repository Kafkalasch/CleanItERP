using System;
using CleanItERP.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DataModel
{
    public class TextileTypeTest : ADbContextTest
    {
        [Fact]
        public void TestTextileReverseNavigationOfTextileType()
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

            type.Textiles.Should().Contain(textile);
        }

        [Fact]
        public void SavingWithoutDescriptionThrows()
        {
            var type = EntityFactory.CreateTextileType();
            type.Description = null;

            using (var context = CreateContext())
            {
                context.Add(type);
                SavingContextShouldThrowNotNullConstrainedFailedException(context);
            }
        }

    }
}