namespace Store.BL.Models
{
    public class UserAuthorizeDTO
    {
        public string Token { get; set; }
        public UserView User { get; set; }
    }
}
