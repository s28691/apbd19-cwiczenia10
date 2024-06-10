namespace apbd19_cwiczenia10.DTOs;

public class MedicamentRequest
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}