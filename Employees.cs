using System.ComponentModel.DataAnnotations;
namespace ProductsDashBoard.Models;
using System.ComponentModel.DataAnnotations.Schema;



public class Employees
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string Phone { get; set; }
    public int Dep_id { get; set; } //ForeignKey

    [ForeignKey("Dep_id")]
    public Departments? departments { get; set; }




    
}