using HospitalAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.WebApi;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {

    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // one to many
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId);

        base.OnModelCreating(modelBuilder);
    }

}