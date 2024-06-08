using apbd19_cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd19_cwiczenia10.Context;

public class apbdContext : DbContext
{
    public apbdContext()
    {
    }

    public apbdContext(DbContextOptions<apbdContext> options) : base(options)
    {
        
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}