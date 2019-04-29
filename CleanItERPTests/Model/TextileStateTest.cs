using System;
using CleanItERP.Model;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Model
{
    public class TextileStateTest : AModelTest
    {
        [Fact]
        public void TestTextileReverseNavigationOfTextileState(){
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

            state.Textiles.Should().Contain(textile);
        }
        
    }
}