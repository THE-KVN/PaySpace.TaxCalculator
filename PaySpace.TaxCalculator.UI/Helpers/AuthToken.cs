namespace PaySpace.TaxCalculator.UI.Helpers
{
    public class AuthToken
    {
        public string tokenType { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public int expiresIn { get; set; }

    }
}
