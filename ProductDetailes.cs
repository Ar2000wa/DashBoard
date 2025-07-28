using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ProductsDashBoard.Models;


public class ProductDetailes
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Color { get; set; }
    public int? Qty { get; set; }
    public decimal Vat { get; set; }
    public string?Image { get; set; }
    public int ProductId { get; set; } //ForeignKey

    [ForeignKey("ProductId")]
    public Products? products { get; set; }


    }








