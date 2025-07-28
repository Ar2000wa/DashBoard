using System.ComponentModel.DataAnnotations;
namespace ProductsDashBoard.Models;




    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="يجب ان يكون الاسم بين 5 و 50 حرف ")]
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }



    }






