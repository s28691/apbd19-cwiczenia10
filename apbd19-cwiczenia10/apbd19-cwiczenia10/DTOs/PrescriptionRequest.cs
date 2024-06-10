namespace apbd19_cwiczenia10.DTOs;

public class PrescriptionRequest
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public int IdDoctor { get; set; }
    public string FirstDocName { get; set; }
    public string LastDocName { get; set; }
    public string Email { get; set; }
    public List<MedicamentRequest> Medicaments { get; set; }
} 