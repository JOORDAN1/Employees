using System.ComponentModel.DataAnnotations;

namespace Employees.Models;

public class JobDto
{
    [Required] [MaxLength(50)]
    public string Name { get; set; }
    
    [Required] [MaxLength(200)]
    public string Description { get; set; }

    //TODO: Zapytac czemu to jest tak ograniczone ze nie moge tu dodac pracownika ani projektu
}