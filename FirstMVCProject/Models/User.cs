using System.ComponentModel.DataAnnotations;

namespace FirstMVCProject.Models
{
    public class User
    {
        public int Userid { get; set; }
       
        public string Name { get; set; }
        [StringLength(14, ErrorMessage = "Maximum character limit is 14!")]
        public string LastName { get; set; }
        [StringLength(25, ErrorMessage = "Maximum character limit is 25!")]
        public string Email { get; set; }
        [EmailAddress]
        public string Password { get; set; }
        
        public decimal Budget { get; set; } = 0;


        public List<Product>? Products { get; set; }

        public virtual ICollection<Sale> SellersSale { get; set; }

        public virtual ICollection<Sale> BuyersSale { get; set; }


      
    }
}
