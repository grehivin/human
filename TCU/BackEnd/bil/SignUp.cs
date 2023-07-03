using BackEnd.dal;
using BackEnd.dal.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.bil
{
    public class SignUp : ISignUp
    {
        private readonly HREContext _hre;

        public SignUp()
        {
            _hre = new HREContext();
        }

        public async Task UserSignUp(Persons person, Users user)
        {
            try
            {
                if (PersonExist(person))
                    return;

                if (UserExist(user))
                    return;

                _hre.Add(person);
                await _hre.SaveChangesAsync();

                var prsn = await _hre.Persons.FirstOrDefaultAsync(p => p.Email == person.Email);
                person.Id = prsn.Id;

                user.PersonId = person.Id;
                user.Enabled = true;
                _hre.Add(user);
                await _hre.SaveChangesAsync();

                var usr = await _hre.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
                user.Id = usr.Id;

                var role = await _hre.Roles.FirstOrDefaultAsync(r => r.Role == "Estudiante");
                _hre.Add(new UserRoles(user.Id, role.Id));
                await _hre.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            return;
        }

        private bool PersonExist(Persons person)
        {
            return _hre.Persons.Any(p => p.Email == person.Email);
        }

        private bool UserExist(Users user)
        {
            return _hre.Users.Any(u => u.Username == user.Username);
        }
    }
}
