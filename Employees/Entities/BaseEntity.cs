using System.ComponentModel.DataAnnotations;

namespace Employees.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}