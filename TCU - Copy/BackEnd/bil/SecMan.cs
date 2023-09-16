using bend.dal;
using bend.dal.entities;

namespace bend.bil
{
    public class SecMan : ISecMan
    {
        private readonly DBContext LearningDB;

        public SecMan() 
        {
            LearningDB = new DBContext();
        }

        public async void Add(Roles r, Users u)
        {
            LearningDB.Add(new UserRoles(u.Id, r.Id));
            await LearningDB.SaveChangesAsync();
        }

        public async void Create(Roles r)
        {
            LearningDB.Add(r);
            await LearningDB.SaveChangesAsync();
        }

        public async void Create(Users u)
        {
            LearningDB.Add(u);
            await LearningDB.SaveChangesAsync();
        }

        public async void Delete(Roles r)
        {
            LearningDB.Remove(r);
            await LearningDB.SaveChangesAsync();
        }

        public async void Delete(Users u)
        {
            LearningDB.Remove(u);
            await LearningDB.SaveChangesAsync();
        }

        public async void Remove(Roles r, Users u)
        {
            LearningDB.Remove(LearningDB.UserRoles.FirstOrDefault(x => x.RoleId == r.Id && x.UserId == u.Id));
            await LearningDB.SaveChangesAsync();
        }

        public async void Update(Roles r)
        {
            LearningDB.Update(r);
            await LearningDB.SaveChangesAsync();
        }

        public async void Update(Users u)
        {
            LearningDB.Update(u);
            await LearningDB.SaveChangesAsync();
        }
    }
}
