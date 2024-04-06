using Microsoft.Build.Evaluation;
using Stock.Models.DbModels.ItemModel;
using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DTO
{
    public class ItemDTO
    {
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        public IFormFile? Icon { get; set; }
        public List<IFormFile>?Images { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price Required"), Range(1, double.MaxValue)]
        public decimal Price { get; set; }



        /// <summary>
        /// Convert From ItemDto To Item
        /// </summary>
        /// <param name="input"></param>
        public static implicit operator Item(ItemDTO input)
            => new()
            {
                Description=input?.Description,
                Name=input.Name,
                Price=input.Price,
                Images=new List<ItemImage>()
            };
        public static implicit operator ItemDTO(Item input)
        => new()
        {
            Description = input?.Description,
            Name = input.Name,
            Price = input.Price,
        };

        /// <summary>
        /// Return New Item Data
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Item ReturnItem(Item input)
        {
            input.Name = this.Name;
            input.Description = this?.Description;
            input.Price = this.Price;
            return input;
        }
    }
}
