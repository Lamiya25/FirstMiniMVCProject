namespace FirstMVCProject.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int? SellerId { get; set; }  

        public User Seller { get; set; }
        public int? BuyerId { get; set; }

        public User Buyer { get; set; } 
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
    }
}
