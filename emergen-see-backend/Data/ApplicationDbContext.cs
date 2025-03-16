using emergen_see_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace emergen_see_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<TriageForm> TriageForms { get; set; }
        public DbSet<Queue> Queues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Queue)
                .WithMany(q => q.Patients)
                .HasForeignKey(p => p.QueueId) // Use the foreign key property
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.AssignedDoctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.AssignedDoctorId) // Use the foreign key property
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.TriageForm)
                .WithOne(tf => tf.Patient)
                .HasForeignKey<Patient>(p => p.TriageFormId); // Specify the foreign key property

            modelBuilder.Entity<Queue>()
                .HasMany(q => q.Patients)
                .WithOne(p => p.Queue)
                .HasForeignKey(p => p.QueueId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Patients)
                .WithOne(p => p.AssignedDoctor)
                .HasForeignKey(p => p.AssignedDoctorId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.TriageForms)
                .WithOne(tf => tf.Doctor)
                .HasForeignKey(tf => tf.DoctorId);

            // Entity Properties
            modelBuilder.Entity<Patient>()
                .Property(p => p.QueueId)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.TriageFormId)
                .IsRequired();

            modelBuilder.Entity<Queue>()
                .Property(q => q.QueueType)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Name)
                .IsRequired();
        }
    }
}