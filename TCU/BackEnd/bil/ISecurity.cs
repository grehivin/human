using BackEnd.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.bil
{
    public interface ISecurity
    {
        public Task<bool> SignUp(Users u);
        public bool Exist(Users u);
        public string GenerateVerificationCode(int length);
        public Users Authenticate(Users u);
        public ClaimsIdentity SetIdentityFor(Users u);
        public Task<bool> ResetPasswordFor(string u, string p);
    }
}
