using bend.dal;
using bend.dal.entities;
using Microsoft.EntityFrameworkCore;

namespace bend.bil
{
    public class Learning : ILearning
    {
        #region Propiedades y constructor
        private readonly HREContext HumanRightsEducation_DB;

        public Learning()
        {
            HumanRightsEducation_DB = new HREContext();
        }
        #endregion

        #region Métodos CRUD
        #region Métodos de creación
        public async Task<bool> Add(Courses course)
        {
            try
            {
                HumanRightsEducation_DB.Add(course);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch
            {
                return false;
                throw new Exception();
            }

            return true;
        }

        public async Task<bool> Add(Topics topic)
        {
            try
            {
                HumanRightsEducation_DB.Add(topic);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch
            {
                return false;
                throw new Exception();
            }

            return true;
        }

        public async Task<bool> Add(Contents content)
        {
            try
            {
                HumanRightsEducation_DB.Add(content);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch
            {
                return false;
                throw new Exception();
            }

            return true;
        }

        public async Task<bool> Add(Options option)
        {
            try
            {
                HumanRightsEducation_DB.Add(option);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch
            {
                return false;
                throw new Exception();
            }

            return true;
        }
        #endregion

        #region Métodos de borado
        public async Task<bool> Delete(Courses course)
        {
            try
            {
                HumanRightsEducation_DB.Courses.Remove(course);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Delete(Topics topic)
        {
            try
            {
                HumanRightsEducation_DB.Topics.Remove(topic);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Delete(Contents content)
        {
            try
            {
                HumanRightsEducation_DB.Contents.Remove(content);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Delete(Options option)
        {
            try
            {
                HumanRightsEducation_DB.Options.Remove(option);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }
        #endregion

        #region Métodos de lectura
        public Contents GetContent(Contents content)
        {
            return GetContents().FirstOrDefault(content);
        }

        public Contents GetContent(int id)
        {
            return GetContents().Find(c => c.Id == id);
        }

        public List<Contents> GetContents()
        {
            try
            {
                return HumanRightsEducation_DB.Contents.ToList();
            }
            catch
            {
                return null;
                throw new Exception();
            }
        }

        public Courses GetCourse(Courses course)
        {
            return GetCourses().FirstOrDefault(course);
        }

        public Courses GetCourse(int id)
        {
            return GetCourses().Find(c => c.Id == id);
        }

        public List<Courses> GetCourses()
        {
            try
            {
                return HumanRightsEducation_DB.Courses.ToList();
            }
            catch
            {
                return null;
                throw new Exception();
            }
        }

        public Options GetOption(Options option)
        {
            return GetOptions().FirstOrDefault(option);
        }

        public Options GetOption(int id)
        {
            return GetOptions().Find(o => o.Id == id);
        }

        public List<Options> GetOptions()
        {
            try
            {
                return HumanRightsEducation_DB.Options.ToList();
            }
            catch
            {
                return null;
                throw new Exception();
            }
        }

        public Topics GetTopic(Topics topic)
        {
            return GetTopics().FirstOrDefault(topic);
        }

        public Topics GetTopic(int id)
        {
            return GetTopics().Find(t => t.Id == id);
        }

        public List<Topics> GetTopics()
        {
            try
            {
                return HumanRightsEducation_DB.Topics.ToList();
            }
            catch
            {
                return null;
                throw new Exception();
            }
        }
        #endregion

        #region Métodos de actualización
        public async Task<bool> Update(Courses course)
        {
            try
            {
                HumanRightsEducation_DB.Update(course);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch
            {
                return false;
                throw new Exception();
            }

            return true;
        }

        public async Task<bool> Update(Topics topic)
        {
            try
            {
                HumanRightsEducation_DB.Update(topic);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch
            {
                return false;
                throw new Exception();
            }

            return true;
        }

        public async Task<bool> Update(Contents content)
        {
            try
            {
                HumanRightsEducation_DB.Update(content);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch
            {
                return false;
                throw new Exception();
            }

            return true;
        }

        public async Task<bool> Update(Options option)
        {
            try
            {
                HumanRightsEducation_DB.Update(option);
                await HumanRightsEducation_DB.SaveChangesAsync();
            }
            catch
            {
                return false;
                throw new Exception();
            }

            return true;
        }
        #endregion
        #endregion

        #region Métodos de operaciones misceláneas
        public async Task<bool> Disable(Courses course)
        {
            try
            {
                course.Enabled = false;
                HumanRightsEducation_DB.Update(course);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Disable(Topics topic)
        {
            try
            {
                topic.Enabled = false;
                HumanRightsEducation_DB.Update(topic);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Disable(Contents content)
        {
            try
            {
                content.Enabled = false;
                HumanRightsEducation_DB.Update(content);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Disable(Options option)
        {
            try
            {
                option.Enabled = false;
                HumanRightsEducation_DB.Update(option);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Enable(Courses course)
        {
            try
            {
                course.Enabled = true;
                HumanRightsEducation_DB.Update(course);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Enable(Topics topic)
        {
            try
            {
                topic.Enabled = true;
                HumanRightsEducation_DB.Update(topic);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Enable(Contents content)
        {
            try
            {
                content.Enabled = true;
                HumanRightsEducation_DB.Update(content);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public async Task<bool> Enable(Options option)
        {
            try
            {
                option.Enabled = true;
                HumanRightsEducation_DB.Update(option);
                await HumanRightsEducation_DB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
                throw new Exception();
            }
        }

        public bool Exist(Courses course)
        {
            var record = new Courses();

            if (course == null)
                return false;

            if (course.Id != 0)
                record = GetCourses().Find(c => c.Id == course.Id);
            else
                record = GetCourses().Find(c => c.Course.ToUpper() == course.Course.ToUpper());

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
                record = GetTopics().Find(t => t.Id == topic.Id);
            else
                record = GetTopics().Find(t => t.Topic.ToUpper() == topic.Topic.ToUpper());

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
                record = GetContents().Find(c => c.Id == content.Id);
            else
                record = GetContents().Find(c => c.Content.ToUpper() == content.Content.ToUpper());

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
                record = GetOptions().Find(o => o.Id == option.Id);
            else
                record = GetOptions().Find(o => o.Descr.ToUpper() == option.Descr.ToUpper());

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

            switch (idType)
            {
                case "course":
                    if (GetCourse(id) != null)
                        return true;

                    break;
                case "topic":
                    if (GetTopic(id) != null)
                        return true;

                    break;
                case "content":
                    if (GetContent(id) != null)
                        return true;

                    break;
                case "option":
                    if (GetOption(id) != null)
                        return true;

                    break;
                default:
                    break;
            }

            return false;
        }
        #endregion
    }
}
