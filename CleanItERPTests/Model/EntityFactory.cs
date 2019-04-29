using System;
using CleanItERP.DataModel;

namespace CleanItERPTests.Model
{
    public static class EntityFactory
    {
        public static UserRole CreateUserRole()
        {
            return new UserRole()
            {
                Description = "TestUserRole"
            };
        }

        public static User CreateUser()
        {
            return new User()
            {
                Name = "JohnDoe",
                UserRole = CreateUserRole()
            };
        }

        public static Employee CreateEmployee()
        {
            return new Employee()
            {
                FirstName = "John",
                LastName = "Doe",
                SocialSecurityNumber = 123456789,
                User = CreateUser()
            };
        }

        public static Customer CreateCustomer()
        {
            return new Customer()
            {
                FirstName = "John",
                LastName = "Doe",
                MemberShipId = 1,
                User = CreateUser()
            };
        }

        public static Branch CreateBranch()
        {
            return new Branch()
            {
                Name = "Flagship Store Vienna",
                City = "Vienna"
            };
        }

        public static Order CreateOrder()
        {
            return new Order()
            {
                Identifier = "TestOrder1",
                Branch = CreateBranch(),
                Customer = CreateCustomer(),
                Clerk = CreateEmployee(),
                DateReceived = DateTime.Now,
                DateReturned = DateTime.Now + TimeSpan.FromDays(1)
            };
        }

        public static TextileType CreateTextileType(){
            return new TextileType(){
                Description = "jeans trousers",
                Price = 1m
            };
        }

        public static TextileState CreateTextileState(){
            return new TextileState(){
                Description = "Drying"
            };
        }

        public static Textile CreateTextile(){
            return new Textile()
            {
                Identifier = "J523",
                TextileType = CreateTextileType(),
                TextileState = CreateTextileState(),
                Order = CreateOrder()
            };
        }

    }
}