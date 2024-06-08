using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd19_cwiczenia10.Models;
[Table("Doctor")]
public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    [Required]
    public string Firstname { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
}