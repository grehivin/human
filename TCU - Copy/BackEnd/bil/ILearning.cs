using bend.dal.entities;

namespace bend.bil
{
    public interface ILearning
    {
        public void CreateCertificate();
        
        public void Enroll(UserCourses userCourse);

        public bool IsApproved(UserCourses userCourse);
        public bool IsApproved(UserResponses userResponse);

        public bool IsComplete(UserCourses userCourse);
        public bool IsComplete(Users _user, Topics _topic);
        public bool IsComplete(UserContents userContent);

        public void Learn(UserContents userContent);
        public void Respond(UserResponses userResponse);

        public void SetApproved(UserCourses userCourse);
        
        public void SetComplete(UserCourses userCourse);
        public void SetComplete(UserContents userContent);
    }
}
