using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DbModels.ItemModel
{
    public class Item
    {
        [Key]
        public Guid ItemId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        public string? Icon { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Price Required"), Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        public bool SoftDelete { get; set; }
        public List<ItemImage> Images { get; set; }
    }
}
