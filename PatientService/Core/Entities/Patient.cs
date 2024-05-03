using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientService.Core.Entities;

public class Patient
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public string Ssn { get; set; }
    public string Mail { get; set; }
    public string Name { get; set; }
}