using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Employees.Entities;

namespace Employees.Models;

public class CreateEmployeeDto
{
    [Required] [MaxLength(20)]
    public string FirstName { get; set; }
    
    [Required] [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required] [MaxLength(50)]
    public string Email { get; set; }
    
    // TODO:Zapytac leszcza czm to jest required
    public int? ProjectId { get; set; }
    
    // TODO:Zapytac leszcza czm to jest required
    public List<JobDto>? Jobs { get; set; }

}