using BackEnd.dal;
using BackEnd.dal.entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.bil
{
    public class Security : ISecurity
    {
        private readonly HREContext _hre;

        public Security()
        {
            _hre = new HREContext();
        }

        public async Task<bool> SignUp(Users user)
        {
            try
            {
                user.Username = user.Email;
                user.Enabled = true;
                _hre.Add(user);
                await _hre.SaveChangesAsync();

                var _user = await _hre.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
                var role = await _hre.Roles.FirstOrDefaultAsync(r => r.Role == "Estudiante");
                _hre.Add(new UserRoles(_user.Id, role.Id));
                await _hre.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                return false;

                throw ex;
            }

            return true;
        }

        public bool Exist(Users user)
        {
            return _hre.Users.Any(u => u.Username == user.Username);
        }

        public string GenerateVerificationCode(int length)
        {
            const string vc = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+[{]};:'\"\\,<.>/?"; // Símbolos (caracteres) válidos, todos disponibles en el teclado.

            Random _random = new Random();
            StringBuilder verificationCode = new StringBuilder(length);

            for (int c = 0; c < length; c++)
                verificationCode.Append(vc[_random.Next(vc.Length)]);

            return verificationCode.ToString();
        }

        public Users Authenticate(Users user)
        {
            if (user == null)
                return user;

            try
            {
                var _user = _hre.Users.FirstOrDefault(u => u.Username == user.Username);

                if (_user == null)
                    return null;

                if (_user.Password != user.Password)
                    return null;

                _user.UserRoles = LoadRolesFor(_user);

                return _user;
            }
            catch
            {
                throw;
            }
        }

        private ICollection<UserRoles> LoadRolesFor(Users user)
        {
            ICollection<UserRoles> _userRoles = new HashSet<UserRoles>();
            List<UserRoles> userRoles = _hre.UserRoles.ToList();
            List<Roles> roles = _hre.Roles.ToList();

            foreach (UserRoles role in userRoles)
                if (role.UserId == user.Id)
                {
                    role.Role = roles.Find(r => r.Id == role.RoleId);

                    _userRoles.Add(role);
                }
            
            return _userRoles;
        }

        public ClaimsIdentity SetIdentityFor(Users user)
        {
            var claims = new List<Claim>()
            {
                new Claim("Usuario", user.Username),
                new Claim(ClaimTypes.Name, user.Username)
            };

            foreach (UserRoles userRole in user.UserRoles)
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Role));

            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> ResetPasswordFor(string user, string password)
        {
            try
            {
                Users _user = await _hre.Users.FirstOrDefaultAsync(u => u.Username == user);

                if (_user == null)
                    return false;

                _user.Password = password;
                _user.ConfirmPassword = password;

                _hre.Update(_user);
                await _hre.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
    }
}
