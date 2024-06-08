using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace apbd19_cwiczenia10.Models;
[Table("Prescription_Medicament")]
public class Prescription_Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; }
    public int IdPrescription { get; set; }
    [ForeignKey(nameof(IdPrescription))]
    public Prescription prescription { get; set; }
    public int? Dose { get; set; }
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}