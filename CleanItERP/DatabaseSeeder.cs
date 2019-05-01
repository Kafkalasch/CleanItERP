using System;
using CleanItERP.DataModel;
using Microsoft.Extensions.DependencyInjection;

namespace CleanItERP
{
    public class DatabaseSeeder
    {
        private CleanItERPContext Context { get; }

        private UserRole CustomerUserRole { get; set; }
        private UserRole EmployeeUserRole { get; set; }
        private UserRole ManagerUserRole { get; set; }

        private User JohnCleanUser { get; set; }
        private User JackDirtyUser { get; set; }
        private User JuliaMessyUser { get; set; }

        private Employee JohnClean { get; set; }
        private Customer JuliaMessy { get; set; }
        private Customer JackDirty { get; set; }

        private Branch Vienna { get; set; }
        private Branch Graz { get; set; }

        private TextileType Jeans { get; set; }
        private TextileType Jacket { get; set; }

        private TextileState Dirty { get; set; }
        private TextileState BeingWashed { get; set; }
        private TextileState Drying { get; set; }
        private TextileState Finished { get; set; }

        private Order JuliasOrder {get; set;}
        private Order JacksOrder {get; set;}

        private Textile JuliasJacket {get; set;}
        private Textile JuliasJeans {get; set;}
        private Textile JacksBlueJacket {get; set;}
        private Textile JacksRedJacket {get; set;}

        public DatabaseSeeder(CleanItERPContext context)
        {
            Context = context;
        }

        public void SeedIfEmpty(){
            Context.Database.EnsureCreated();

            if(Context.Branches.IsEmpty()){
                Seed();
            }
        }
        public void Seed()
        {
            Context.Database.EnsureCreated();

            CreateUserRoles();
            CreateUsers();
            CreateEmployees();
            CreateCustomers();
            CreateBranches();
            CreateTextileTypes();
            CreateTextileStates();
            CreateOrders();
            CreateTextiles();

            Context.SaveChanges();
        }

        private void CreateUserRoles()
        {
            CustomerUserRole = new UserRole()
            {
                Description = "Customer"
            };

            EmployeeUserRole = new UserRole()
            {
                Description = "Employee"
            };

            ManagerUserRole = new UserRole()
            {
                Description = "Manager"
            };

            Context.Add(CustomerUserRole);
            Context.Add(EmployeeUserRole);
            Context.Add(ManagerUserRole);
        }

        private void CreateUsers()
        {
            JohnCleanUser = new User()
            {
                Name = "JohnClean",
                UserRole = EmployeeUserRole
            };

            JackDirtyUser = new User()
            {
                Name = "JackDirty",
                UserRole = CustomerUserRole
            };

            JuliaMessyUser = new User()
            {
                Name = "Julia Messy",
                UserRole = CustomerUserRole
            };

            Context.Add(JohnCleanUser);
            Context.Add(JackDirtyUser);
            Context.Add(JuliaMessyUser);
        }

        private void CreateEmployees()
        {
            JohnClean = new Employee()
            {
                FirstName = "John",
                LastName = "Clean",
                User = JohnCleanUser,
                SocialSecurityNumber = 123456789
            };
            Context.Add(JohnClean);
        }

        private void CreateCustomers()
        {
            JuliaMessy = new Customer()
            {
                FirstName = "Julia",
                LastName = "Messy",
                MemberShipId = 2,
                User = JuliaMessyUser
            };

            JackDirty = new Customer()
            {
                FirstName = "Jack",
                LastName = "Dirty",
                MemberShipId = 1,
                User = JackDirtyUser,
            };

            Context.Add(JuliaMessy);
            Context.Add(JackDirty);
        }

        private void CreateBranches()
        {
            Vienna = new Branch()
            {
                Name = "Clean It! - Wien",
                City = "Wien"
            };

            Graz = new Branch()
            {
                Name = "Clean It! - Graz",
                City = "Graz"
            };

            Context.Add(Vienna);
            Context.Add(Graz);
        }

        private void CreateTextileTypes()
        {
            Jeans = new TextileType()
            {
                Description = "Jeans Trousers"
            };

            Jacket = new TextileType()
            {
                Description = "Jacket"
            };

            Context.Add(Jeans);
            Context.Add(Jacket);
        }

        private void CreateTextileStates()
        {
            Dirty = new TextileState() { Description = "Dirty" };
            BeingWashed = new TextileState() { Description = "Being Washed" };
            Drying = new TextileState() { Description = "Drying" };
            Finished = new TextileState() { Description = "Finished" };

            Context.Add(Dirty);
            Context.Add(BeingWashed);
            Context.Add(Drying);
            Context.Add(Finished);
        }

        private void CreateOrders(){
            JuliasOrder = new Order(){
                Identifier = "Julia's Order",
                Branch = Vienna,
                Clerk = JohnClean,
                Customer = JuliaMessy,
                DateReceived = new DateTime(2019, 04, 29, 12, 0, 0),
                DateReturned = null
            };

            JacksOrder = new Order(){
                Identifier = "Jack's Order", 
                Branch = Vienna,
                Clerk = JohnClean,
                Customer = JackDirty,
                DateReceived = new DateTime(2019, 04, 29, 14, 30, 0),
                DateReturned = null
            };

            Context.Add(JuliasOrder);
            Context.Add(JacksOrder);
        }

        private void CreateTextiles(){
            JuliasJeans = new Textile(){
                Identifier = "Julia's Jeans",
                Order = JuliasOrder,
                TextileType = Jeans,
                TextileState = Finished
            };

            JuliasJacket = new Textile(){
                Identifier = "Julia's Jacket",
                Order = JuliasOrder,
                TextileType = Jacket,
                TextileState = Finished
            };

            JacksBlueJacket = new Textile(){
                Identifier = "Julia's Blue Jacket",
                Order = JacksOrder,
                TextileType = Jacket,
                TextileState = BeingWashed
            };

            JacksRedJacket = new Textile(){
                Identifier = "Julia's Red Jacket",
                Order = JacksOrder,
                TextileType = Jacket,
                TextileState = Drying
            };

            Context.Add(JuliasJeans);
            Context.Add(JuliasJacket);
            Context.Add(JacksBlueJacket);
            Context.Add(JacksRedJacket);
        }

    }
}