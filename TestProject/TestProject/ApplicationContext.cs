namespace TestProject
{
    using Microsoft.EntityFrameworkCore;
    using TestProject.Models;

    public class ApplicationContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; } = null!;
        public DbSet<Distributor> Distributors { get; set; } = null!;
        public ApplicationContext()     
        {
            Database.EnsureCreated();   
        }
    }
}
