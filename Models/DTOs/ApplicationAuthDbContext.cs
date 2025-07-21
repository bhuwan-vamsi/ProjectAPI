using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagerTest.Data
{
    public class ApplicationAuthDbContext : IdentityDbContext
    {
        public ApplicationAuthDbContext(DbContextOptions<ApplicationAuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var managerId = "35da3d5d-79f4-44e0-8d6b-08d0dcf75991";
            var employeeId = "9d12498c - de59 - 46af - a8f2 - 81e7cee88f7c";
            var roles = new List<IdentityRole> {
                new IdentityRole { 
                    Id = managerId, 
                    ConcurrencyStamp = managerId, 
                    Name= "Manager", 
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = employeeId,
                    ConcurrencyStamp = employeeId,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
