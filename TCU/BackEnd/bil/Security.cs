using bend.dal;
using bend.dal.entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace bend.bil
{
    public class Security : ISecurity
    {
        private readonly HREContext HumanRightsEducation_DB;

        public Security()
        {
            HumanRightsEducation_DB = new HREContext();
        }

        public async Task<bool> SignUp(Users user)
        {
            try
            {
                user.Username = user.Email;
                user.Enabled = true;
                HumanRightsEducation_DB.Add(user);
                await HumanRightsEducation_DB.SaveChangesAsync();

                var _user = await HumanRightsEducation_DB.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
                var role = await HumanRightsEducation_DB.Roles.FirstOrDefaultAsync(r => r.Role == "Estudiante");
                HumanRightsEducation_DB.Add(new UserRoles(_user.Id, role.Id));
                await HumanRightsEducation_DB.SaveChangesAsync();
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
            return HumanRightsEducation_DB.Users.Any(u => u.Username == user.Username);
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
                var _user = HumanRightsEducation_DB.Users.FirstOrDefault(u => u.Username == user.Username);

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
            List<UserRoles> userRoles = HumanRightsEducation_DB.UserRoles.ToList();
            List<Roles> roles = HumanRightsEducation_DB.Roles.ToList();

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
                Users _user = await HumanRightsEducation_DB.Users.FirstOrDefaultAsync(u => u.Username == user);

                if (_user == null)
                    return false;

                _user.Password = password;
                _user.ConfirmPassword = password;

                HumanRightsEducation_DB.Update(_user);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
    }
}
