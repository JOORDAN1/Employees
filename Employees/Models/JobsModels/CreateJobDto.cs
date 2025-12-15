using System.ComponentModel.DataAnnotations;

namespace Employees.Models.JobsModels;

public class CreateJobDto
{
    [Required] [MaxLength(50)]
    public string Name { get; set; }
    
    [Required] [MaxLength(200)]
    public string Description { get; set; }
    
    public int EmployeeId { get; set; }
    //TODO:Czemu to musi byc -> jak napisac migracje zeby przeszlo bez tego
}