using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Entities;


[Table("Jobs")]
public class Job : BaseEntity
{
    [Required] [MaxLength(50)]
    public string Name { get; set; }
    
    [Required] [MaxLength(200)]
    public string Description { get; set; }
    
    public int? EmployeeId { get; set; }
    
    public Employee? Employee { get; set; }
    
    //TODO: czy moge go jakos mozna to zmienic tutaj zeby mzona bylo potempokazac pracownikow i projekt

}