using apbd19_cwiczenia10.Context;
using apbd19_cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd19_cwiczenia10.Services;

public class DbService : IDbService
{
    private readonly apbdContext _context;
    public DbService(apbdContext context)
    {
        _context = context;
    }
    public async Task<bool> DoesMedicamentExist(int IdMedicament)
    {
        return await _context.Medicaments.AnyAsync(m =>
            m.IdMedicament == IdMedicament);
    }

    public async Task<bool> DoesPatientExist(int IdPatient)
    {
        return await _context.Patients.AnyAsync(p => p.IdPatient == IdPatient);
    }

    public async Task AddNewPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task AddNewPrescription(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task AddPrescriptionMedicaments(List<Prescription_Medicament> medicaments)
    {
        await _context.AddRangeAsync(medicaments);
        await _context.SaveChangesAsync();
    }
}

