using System.ComponentModel.DataAnnotations;

namespace Category.Api.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
