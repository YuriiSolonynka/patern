using Microsoft.EntityFrameworkCore;


namespace patern
{
    public class ApplicationContext : DbContext
    
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Hub> Hubs { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<MotionSensor> MotionSensors { get; set; }
        public DbSet<SmokeSensor> SmokeSensors { get; set; }
        public DbSet<SecurityService> SecurityServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sensor>()
                .HasDiscriminator<string>("SensorType")
                .HasValue<MotionSensor>("Motion")
                .HasValue<SmokeSensor>("Smoke");

            modelBuilder.Entity<Sensor>()
                .HasOne(s => s.Hub)
                .WithMany(h => h.Sensors)
                .HasForeignKey(s => s.HubId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.SecurityService)
                .WithMany(ss => ss.Notifications)
                .HasForeignKey(n => n.SecurityServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Hub)
                .WithMany(h => h.Notifications)
                .HasForeignKey(n => n.HubId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hub>()
                .HasOne(n => n.User)
                .WithMany(s => s.Hubs)
                .HasForeignKey(n => n.UserId);
                
            modelBuilder.Entity<Hub>()
                .HasOne(n => n.SecurityService)
                .WithMany(o => o.Hubs)
                .HasForeignKey(n => n.SecurityServiceId);
        }
    }
}