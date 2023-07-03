using BackEnd.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.bil
{
    public interface ISignUp
    {
        public Task UserSignUp(Persons p, Users u);
    }
}
