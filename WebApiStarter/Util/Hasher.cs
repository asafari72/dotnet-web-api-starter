using Microsoft.AspNetCore.Identity;

namespace WebApiStarter.Util
{
    public class Hasher
    {
        public string hash(string password)
        {
            return new PasswordHasher<object?>().HashPassword(null, password);
        }

        public string verify(string password, string hashedPassword)
        {
            var passwordVerificationResult = new PasswordHasher<object?>().VerifyHashedPassword(null, hashedPassword, password);
            switch (passwordVerificationResult)
            {
                case PasswordVerificationResult.Failed:
                    return "Password incorrect.";

                case PasswordVerificationResult.Success:
                    return "Password ok.";

                case PasswordVerificationResult.SuccessRehashNeeded:
                    return "Password ok but should be rehashed and updated.";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
