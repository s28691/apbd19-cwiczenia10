using apbd19_cwiczenia10.Models;

namespace apbd19_cwiczenia10.Services;

public interface IDbService
{
    Task<bool> DoesMedicamentExist(int IdMedicament);
    Task<bool> DoesPatientExist(int IdPatient);
    Task AddNewPatient(Patient patient);
    Task AddNewPrescription(Prescription prescription);
    Task AddPrescriptionMedicaments(List<Prescription_Medicament> medicaments);
}