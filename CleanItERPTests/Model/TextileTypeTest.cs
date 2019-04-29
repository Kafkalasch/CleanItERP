using System;
using CleanItERP.Model;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Model
{
    public class TextileTypeTest : AModelTest
    {
        [Fact]
        public void TestTextileReverseNavigationOfTextileType(){
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
        public void SavingTextileTypeWithoutDescriptionThrows(){
            var type = EntityFactory.CreateTextileType();
            type.Description = null;

            using(var context = CreateContext()){
                context.Add(type);
                SavingContextShouldThrowNotNullConstrainedFailedException(context);
            }
        }
        
    }
}