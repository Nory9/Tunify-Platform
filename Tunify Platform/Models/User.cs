namespace Tunify_Platform.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Join_Date { get; set; }
        public int Subscription_ID { get; set; }  //FK

    }
}
