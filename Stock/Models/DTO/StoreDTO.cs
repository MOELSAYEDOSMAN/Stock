using System.ComponentModel.DataAnnotations;

namespace Stock.Models.DTO
{
    public class StoreDTO
    {
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }

        public IFormFile? Icon { get; set; }

        [Required(ErrorMessage = "Phone Required"), StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "You Must Enter 11 Numbers"),
            RegularExpression(@"^01[0125][1-9]{8}$", ErrorMessage = "01[0|1|2|5]*******")]
        public string PhoneNumber { get; set; }
       

        /// <summary>
        /// Convert From StoreDto To store
        /// </summary>
        /// <param name="input"></param>
        public static implicit operator Store(StoreDTO input)
        => new()
        {
            Name = input.Name,
            Address = input.Address,
            PhoneNumber = input.PhoneNumber
        };
        public static implicit operator StoreDTO(Store input)
        => new()
        {
            Name = input.Name,
            Address = input.Address,
            PhoneNumber = input.PhoneNumber
        };

        /// <summary>
        /// Return New Store Data
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Store ReturnStore(Store input)
        {
            input.PhoneNumber = this.PhoneNumber;
            input.Name = this.Name;
            input.Address=this.Address;
            return input;
        }
    }
}
