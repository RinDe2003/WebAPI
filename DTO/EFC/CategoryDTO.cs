using WebAPI_1721030646.Models;

namespace WebAPI_1721030646.DTO.EFC
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Descriptions { get; set; }
    }
}
