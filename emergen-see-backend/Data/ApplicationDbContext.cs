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

            // Patient to Queue
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Queue)
                .WithMany(q => q.Patients)
                .HasForeignKey(p => p.QueueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Patient to Doctor
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.AssignedDoctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.AssignedDoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Patient to TriageForm (One-to-One)
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.TriageForm)
                .WithOne(tf => tf.Patient)
                .HasForeignKey<TriageForm>(tf => tf.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // TriageForm to Nurse
            modelBuilder.Entity<TriageForm>()
                .HasOne(tf => tf.Nurse)
                .WithMany(n => n.TriageForms)
                .HasForeignKey(tf => tf.NurseId)
                .OnDelete(DeleteBehavior.Restrict);

            // TriageForm to Doctor
            modelBuilder.Entity<TriageForm>()
                .HasOne(tf => tf.Doctor)
                .WithMany(d => d.TriageForms)
                .HasForeignKey(tf => tf.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Queue to Patient
            modelBuilder.Entity<Queue>()
                .HasMany(q => q.Patients)
                .WithOne(p => p.Queue)
                .HasForeignKey(p => p.QueueId);

            // Doctor to Patient
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Patients)
                .WithOne(p => p.AssignedDoctor)
                .HasForeignKey(p => p.AssignedDoctorId);

            // Doctor to TriageForm
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.TriageForms)
                .WithOne(tf => tf.Doctor)
                .HasForeignKey(tf => tf.DoctorId);

            // Entity Properties
            modelBuilder.Entity<Patient>()
                .Property(p => p.QueueId)
                .IsRequired();

            modelBuilder.Entity<Queue>()
                .Property(q => q.QueueType)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<TriageForm>()
                .Property(t => t.Symptoms)
                .IsRequired();
            modelBuilder.Entity<TriageForm>()
                .Property(t => t.Diagnosis)
                .IsRequired();
        }
    }
}