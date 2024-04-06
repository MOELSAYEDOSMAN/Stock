using Microsoft.EntityFrameworkCore;

namespace Stock.Models.DbModels.ItemModel
{
    [Owned]
    public class ItemImage
    {
        public string Src { get; set; }


        public static implicit operator ItemImage(string src)
        => new()
        {
            Src = src,
        };
    }
}
