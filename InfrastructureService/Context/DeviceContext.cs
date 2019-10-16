using Infrastructure.Model;
using InfrastructureService.Config;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureService.Context
{
    public class DeviceContext : DbContext
    {
        public virtual DbSet<Device> Device { get; set; }


        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder
                .ApplyConfiguration(new DeviceConfiguration()));
        }
    }
}
