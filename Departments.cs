using System.ComponentModel.DataAnnotations;
namespace ProductsDashBoard.Models;


public class Departments
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Number { get; set; }
    public string? Description{ get; set; }
    
}