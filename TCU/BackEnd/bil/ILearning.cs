using bend.dal.entities;

namespace bend.bil
{
    public interface ILearning
    {
        public Courses GetCourse(Courses course);
        public Courses GetCourse(int id);
        public List<Courses> GetCourses();
        public Topics GetTopic(Topics topic);
        public Topics GetTopic(int id);
        public List<Topics> GetTopics();
        public Contents GetContent(Contents content);
        public Contents GetContent(int id);
        public List<Contents> GetContents();
        public Options GetOption(Options option);
        public Options GetOption(int id);
        public List<Options> GetOptions();

        public Task<bool> Add(Courses course);
        public Task<bool> Add(Topics topic);
        public Task<bool> Add(Contents content);
        public Task<bool> Add(Options option);

        public Task<bool> Update(Courses course);
        public Task<bool> Update(Topics topic);
        public Task<bool> Update(Contents content);
        public Task<bool> Update(Options option);

        public Task<bool> Delete(Courses course);
        public Task<bool> Delete(Topics topic);
        public Task<bool> Delete(Contents content);
        public Task<bool> Delete(Options option);

        public Task<bool> Enable(Courses course);
        public Task<bool> Enable(Topics topic);
        public Task<bool> Enable(Contents content);
        public Task<bool> Enable(Options option);
        public Task<bool> Disable(Courses course);
        public Task<bool> Disable(Topics topic);
        public Task<bool> Disable(Contents content);
        public Task<bool> Disable(Options option);

        public bool Exist(Courses course);
        public bool Exist(Topics topic);
        public bool Exist(Contents content);
        public bool Exist(Options option);
        public bool Exist(string idType, int id);
    }
}
