using HospitalAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Doctor tablosu için konfigürasyon
        modelBuilder.Entity<Doctor>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<Doctor>()
            .Property(d => d.Name)
            .IsRequired(); // İsim alanı boş bırakılamaz

        // Appointment tablosu için konfigürasyon
        modelBuilder.Entity<Appointment>()
            .HasKey(a => new { a.PatientId, a.AppointmentDate }); // Bir randevu için hasta ve tarih birlikte benzersiz olmalı

        modelBuilder.Entity<Appointment>()
            .HasOne<Doctor>()
            .WithMany(d => d.Appointment)
            .HasForeignKey(a => a.DoctorId);
    }
}
