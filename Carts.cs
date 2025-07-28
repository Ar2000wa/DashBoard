using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsDashBoard.Models;

public class Cart
{

    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Products? products{  get; set; }
    public int Qty { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}