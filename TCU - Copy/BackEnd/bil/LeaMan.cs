using bend.dal;
using bend.dal.entities;
using Microsoft.EntityFrameworkCore;

namespace bend.bil
{
    public class LeaMan : ILeaMan
    {
        #region Propiedades y constructor
        private readonly DBContext LearningDB;

        public LeaMan()
        {
            LearningDB = new DBContext();
        }
        #endregion

        #region Métodos CRUD
        #region Métodos de creación
        public async Task<bool> Add(Courses course)
        {
            try
            {
                LearningDB.Add(course);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Add(Topics topic)
        {
            try
            {
                LearningDB.Add(topic);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Add(Contents content)
        {
            try
            {
                LearningDB.Add(content);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Add(Options option)
        {
            try
            {
                LearningDB.Add(option);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Métodos de borrado
        public async Task<bool> Delete(Courses course)
        {
            try
            {
                LearningDB.Courses.Remove(course);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Topics topic)
        {
            try
            {
                LearningDB.Topics.Remove(topic);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Contents content)
        {
            try
            {
                LearningDB.Contents.Remove(content);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Options option)
        {
            try
            {
                LearningDB.Options.Remove(option);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Métodos de lectura
        public Contents GetContent(Contents content)
        {
            return LearningDB.Contents.FirstOrDefault(content);
        }

        public Contents GetContent(int id)
        {
            return LearningDB.Contents.ToList().Find(c => c.Id == id);
        }

        public Courses GetCourse(Courses course)
        {
            return LearningDB.Courses.FirstOrDefault(course);
        }

        public Courses GetCourse(int id)
        {
            return LearningDB.Courses.ToList().Find(c => c.Id == id);
        }

        public Options GetOption(Options option)
        {
            return LearningDB.Options.FirstOrDefault(option);
        }

        public Options GetOption(int id)
        {
            return LearningDB.Options.ToList().Find(o => o.Id == id);
        }

        public Topics GetTopic(Topics topic)
        {
            return LearningDB.Topics.FirstOrDefault(topic);
        }

        public Topics GetTopic(int id)
        {
            return LearningDB.Topics.ToList().Find(t => t.Id == id);
        }
        #endregion

        #region Métodos de actualización
        public async Task<bool> Update(Courses course)
        {
            try
            {
                LearningDB.Update(course);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Topics topic)
        {
            try
            {
                LearningDB.Update(topic);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Contents content)
        {
            try
            {
                LearningDB.Update(content);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Options option)
        {
            try
            {
                LearningDB.Update(option);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #endregion

        #region Métodos de operaciones misceláneas
        public async Task<bool> Disable(Courses course)
        {
            try
            {
                course.Enabled = false;
                LearningDB.Update(course);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Disable(Topics topic)
        {
            try
            {
                topic.Enabled = false;
                LearningDB.Update(topic);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Disable(Contents content)
        {
            try
            {
                content.Enabled = false;
                LearningDB.Update(content);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Disable(Options option)
        {
            try
            {
                option.Enabled = false;
                LearningDB.Update(option);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Enable(Courses course)
        {
            try
            {
                course.Enabled = true;
                LearningDB.Update(course);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Enable(Topics topic)
        {
            try
            {
                topic.Enabled = true;
                LearningDB.Update(topic);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Enable(Contents content)
        {
            try
            {
                content.Enabled = true;
                LearningDB.Update(content);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Enable(Options option)
        {
            try
            {
                option.Enabled = true;
                LearningDB.Update(option);
                await LearningDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Exist(Courses course)
        {
            var record = new Courses();

            if (course == null)
                return false;

            if (course.Id != 0)
                record = LearningDB.Courses.ToList().Find(c => c.Id == course.Id);
            else
                record = LearningDB.Courses.ToList().Find(c => c.Course.ToUpper() == course.Course.ToUpper());

            if (record == null)
                return false;

            return true;
        }

        public bool Exist(Topics topic)
        {
            var record = new Topics();

            if (topic == null)
                return false;

            if (topic.Id != 0)
                record = LearningDB.Topics.ToList().Find(t => t.Id == topic.Id);
            else
                record = LearningDB.Topics.ToList().Find(t => t.Topic.ToUpper() == topic.Topic.ToUpper());

            if (record == null)
                return false;

            return true;
        }

        public bool Exist(Contents content)
        {
            var record = new Contents();

            if (content == null)
                return false;

            if (content.Id != 0)
                record = LearningDB.Contents.ToList().Find(c => c.Id == content.Id);
            else
                record = LearningDB.Contents.ToList().Find(c => c.Content.ToUpper() == content.Content.ToUpper());

            if (record == null)
                return false;

            return true;
        }

        public bool Exist(Options option)
        {
            var record = new Options();

            if (option == null)
                return false;

            if (option.Id != 0)
                record = LearningDB.Options.ToList().Find(o => o.Id == option.Id);
            else
                record = LearningDB.Options.ToList().Find(o => o.Descr.ToUpper() == option.Descr.ToUpper());

            if (record == null)
                return false;

            return true;
        }

        public bool Exist(string idType, int id)
        {
            if (id == 0)
                return false;

            if (idType == string.Empty || idType == null)
                return false;

            if (idType == "course" && GetCourse(id) != null)
                return true;

            if (idType == "topic" && GetTopic(id) != null)
                return true;

            if (idType == "content" && GetContent(id) != null)
                return true;

            if (idType == "option" && GetOption(id) != null)
                return true;

            return false;
        }
        #endregion
    }
}
