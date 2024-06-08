using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd19_cwiczenia10.Models;
[Table("Patient")]
public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateOnly Birthdate { get; set; }
}