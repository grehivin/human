using bend.dal.entities;
using System.Security.Claims;

namespace bend.bil
{
    public interface IUserSession
    {
        public Task<bool> SignUp(Users u);
        public bool Exist(Users u);
        public string GenerateVerificationCode(int length);
        public Users Authenticate(Users u);
        public ClaimsIdentity SetIdentityFor(Users u);
        public Task<bool> ResetPasswordFor(string u, string p);
    }
}
