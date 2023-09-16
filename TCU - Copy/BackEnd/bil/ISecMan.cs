using bend.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bend.bil
{
    public interface ISecMan
    {
        public void Create(Roles r);
        public void Create(Users u);
        public void Update(Roles r);
        public void Update(Users u);
        public void Delete(Roles r);
        public void Delete(Users u);
        public void Add(Roles r, Users u);
        public void Remove(Roles r, Users u);
    }
}
