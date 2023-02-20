using AlahlyMomknTask.Models.Business;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AlahlyMomknTask.Server.Services
{
    public class MainDBContext : DbContext
    {

        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User()
            {
                ID = Guid.NewGuid(),
                Username = "User1",
                Email = "user1@mail.com",
                IsActive = true,
                Password = "$2a$12$64XpCZjUHeTY9WZc1NRJle9Imn1gBo29O3.QCTeniyP4f2Zkad2iy"
            },
            new User()
            {
                ID = Guid.NewGuid(),
                Username = "User2",
                Email = "user2@mail.com",
                IsActive = true,
                Password = "$2a$12$64XpCZjUHeTY9WZc1NRJle9Imn1gBo29O3.QCTeniyP4f2Zkad2iy"
            });
        }
        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<TabStep> TabSteps { get; set; }
        public DbSet<StepItem> StepItems { get; set; }
        #endregion
    }
}
