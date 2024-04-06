using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DbModels.StoreModel
{
    public class Store
    {
        [Key]
        public Guid StoreId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }

        public string? Icon { get; set; }

        [Required(ErrorMessage = "Phone Required"), StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "You Must Enter 11 Numbers"),
            RegularExpression(@"^01[0125][1-9]{8}$", ErrorMessage = "01[0|1|2|5]*******")]
        public string PhoneNumber { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
