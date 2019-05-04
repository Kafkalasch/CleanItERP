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

        private Order JuliasFirstOrder {get; set;}
        private Order JuliasSecondOrder {get; set;}

        private Order JacksOrder {get; set;}

        private Textile JuliasJacket {get; set;}
        private Textile JuliasBlueJeans {get; set;}
        private Textile JuliasRedJeans {get; set;}
        private Textile JuliasGreenJeans {get; set;}

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
            Dirty = new TextileState() { Description = DatabaseConstants.TextileState.DIRTY };
            BeingWashed = new TextileState() { Description = DatabaseConstants.TextileState.BEING_WASHED };
            Drying = new TextileState() { Description = DatabaseConstants.TextileState.DRYING };
            Finished = new TextileState() { Description = DatabaseConstants.TextileState.FINISHED };

            Context.Add(Dirty);
            Context.Add(BeingWashed);
            Context.Add(Drying);
            Context.Add(Finished);
        }

        private void CreateOrders(){
            JuliasFirstOrder = new Order(){
                Identifier = "Julia's first Order",
                Branch = Vienna,
                Clerk = JohnClean,
                Customer = JuliaMessy,
                DateReceived = new DateTime(2019, 04, 29, 12, 0, 0),
                DateReturned = null
            };

            JuliasSecondOrder = new Order(){
                Identifier = "Julia's second Order",
                Branch = Vienna,
                Clerk = JohnClean,
                Customer = JuliaMessy,
                DateReceived = new DateTime(2019, 04, 30, 12, 0, 0),
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

            Context.Add(JuliasFirstOrder);
            Context.Add(JuliasSecondOrder);
            Context.Add(JacksOrder);
        }

        private void CreateTextiles(){
            JuliasBlueJeans = new Textile(){
                Identifier = "Julia's blue Jeans",
                Order = JuliasFirstOrder,
                TextileType = Jeans,
                TextileState = Finished
            };

            JuliasJacket = new Textile(){
                Identifier = "Julia's Jacket",
                Order = JuliasFirstOrder,
                TextileType = Jacket,
                TextileState = Finished
            };

            JuliasRedJeans = new Textile(){
                Identifier = "Julia's red Jeans",
                Order = JuliasSecondOrder,
                TextileType = Jeans,
                TextileState = Finished
            };

            JuliasGreenJeans = new Textile(){
                Identifier = "Julia's green Jeans",
                Order = JuliasSecondOrder,
                TextileType = Jeans,
                TextileState = Finished
            };

            JacksBlueJacket = new Textile(){
                Identifier = "Jacks's blue Jacket",
                Order = JacksOrder,
                TextileType = Jacket,
                TextileState = BeingWashed
            };

            JacksRedJacket = new Textile(){
                Identifier = "Jack's red Jacket",
                Order = JacksOrder,
                TextileType = Jacket,
                TextileState = Drying
            };

            Context.Add(JuliasBlueJeans);
            Context.Add(JuliasJacket);
            Context.Add(JuliasRedJeans);
            Context.Add(JuliasGreenJeans);
            Context.Add(JacksBlueJacket);
            Context.Add(JacksRedJacket);
        }

    }
}