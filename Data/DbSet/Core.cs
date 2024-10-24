using Domain.Entity.Auth;
using Domain.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace Data.Extensions
{
    public partial class DataContext
    {
        /*
         * This holds all the Data sets that relate to the core tables
         */
        public DbSet<Application> Applications { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserCustomerApplication> UserCustomerApplications { get; set; }
        public DbSet<BusinessAreaType> BusinessAreaTypes { get; set; }
        public DbSet<BusinessArea> BusinessAreas { get; set; }
        public DbSet<BusinessAreaTypeRelationship> BusinessAreaTypeRelationships { get; set; }
        public DbSet<BusinessAreaRelationship> BusinessAreaRelationships { get; set; }
        public DbSet<CustomerBusinessArea> CustomerBusinessAreas { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
