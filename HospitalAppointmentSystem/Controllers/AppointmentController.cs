using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AppointmentController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
    {
        return await _context.Appointments.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Appointment>> CreateAppointment([FromBody] Appointment appointment)
    {
        if (appointment == null)
            return BadRequest("Appointment cannot be null.");

        if (appointment.AppointmentDate < DateTime.UtcNow.AddDays(3))
            return BadRequest("Appointment date must be at least 3 days from today.");

        // 10 randevu sınırı
        var doctorAppointmentsCount = await _context.Appointments.CountAsync(a => a.DoctorId == appointment.DoctorId);
        if (doctorAppointmentsCount >= 10)
            return BadRequest("Doctor can have a maximum of 10 appointments.");

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAppointments), new { id = appointment.PatientId }, appointment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(Guid id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null) return NotFound();

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
