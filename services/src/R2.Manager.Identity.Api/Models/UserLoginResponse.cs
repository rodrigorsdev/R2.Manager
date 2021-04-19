namespace R2.Manager.Identity.Api.Models
{
    public class UserLoginResponse
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken Token { get; set; }
    }
}
