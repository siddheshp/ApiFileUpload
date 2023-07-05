using System.ComponentModel.DataAnnotations;

namespace ApiFileUpload.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
