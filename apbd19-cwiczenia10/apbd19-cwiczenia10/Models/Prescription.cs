using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd19_cwiczenia10.Models;
[Table("Prescription")]
public class Prescription
{
    [Key] 
    public int IdPrescription { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public DateOnly DueDate { get; set; }
    public int IdPatient { get; set; }
    [ForeignKey(nameof(IdPatient))]
    public Patient patient { get; set; }
    public int IdDoctor { get; set; }
    [ForeignKey(nameof(IdDoctor))]
    public Doctor doctor { get; set; }
}