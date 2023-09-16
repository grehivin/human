using bend.dal.entities;
using bend.dal;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;

namespace bend.bil
{
    public class UserSession : IUserSession
    {
        private readonly DBContext LearningDB;
        private Users User;

        public UserSession()
        {
            LearningDB = new DBContext();
            User = new Users();
        }

        public async Task<bool> SignUp(Users user)
        {
            try
            {
                user.UserName = user.Email;
                user.Enabled = true;
                LearningDB.Add(user);
                await LearningDB.SaveChangesAsync();

                var _user = await LearningDB.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
                var role = await LearningDB.Roles.FirstOrDefaultAsync(r => r.Role == "Estudiante");
                LearningDB.Add(new UserRoles(_user.Id, role.Id));
                await LearningDB.SaveChangesAsync();
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
            return LearningDB.Users.Any(u => u.UserName == user.UserName);
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
                var _user = LearningDB.Users.FirstOrDefault(u => u.UserName == user.UserName);
                User = _user;

                if (User == null)
                    return null;

                if (User.Password != user.Password)
                    return null;

                // User.UserRoles = LearningDB.GetUserRoles(User);

                LoadRoles();
                //LoadCourses();
                //LoadContents();
                //LoadResponses();

                return User;
            }
            catch
            {
                throw;
            }
        }

        public ClaimsIdentity SetIdentityFor(Users user)
        {
            var claims = new List<Claim>()
            {
                new Claim("Usuario", user.UserName),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach (UserRoles userRole in user.UserRoles)
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Role));

            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> ResetPasswordFor(string user, string password)
        {
            try
            {
                Users _user = await LearningDB.Users.FirstOrDefaultAsync(u => u.UserName == user);

                if (_user == null)
                    return false;

                _user.Password = password;
                // _user.ConfirmPassword = password;

                LearningDB.Update(_user);
                await LearningDB.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        private void LoadRoles()
        {
            foreach (UserRoles userRole in LearningDB.UserRoles)
                if (userRole.UserId == User.Id)
                {
                    userRole.Role = LearningDB.Roles.Find(userRole.RoleId);

                    User.UserRoles.Add(userRole);
                }
        }
    }
}
