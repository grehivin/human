using bend.dal;
using bend.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bend.bil
{
    public class Learning : ILearning
    {
        private readonly DBContext LearningDB;

        public Learning()
        {
            LearningDB = new DBContext();
        }

        public void CreateCertificate()
        {
            throw new NotImplementedException();
        }

        public async void Enroll(UserCourses userCourse)
        {
            try
            {
                LearningDB.Add(userCourse);
                await LearningDB.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public bool IsApproved(UserCourses userCourse)
        {
            return userCourse.Approved;
        }

        public bool IsApproved(UserResponses userResponse)
        {
            return userResponse.Option.Valid;
        }

        public bool IsComplete(UserCourses userCourse)
        {
            return userCourse.Completed;
        }

        public bool IsComplete(Users _user, Topics _topic)
        {
            int completedContents = 0;

            foreach (Contents content in _topic.Contents)
                if (LearningDB.UserContents.ToList().Find(uc => uc.UserId == _user.Id && uc.ContentId == content.Id).Completed)
                    completedContents++;

            if (completedContents == _topic.Contents.Count)
                return false;

            return false;
        }

        public bool IsComplete(UserContents userContent)
        {
            return userContent.Completed;
        }

        public async void Learn(UserContents userContent)
        {
            try
            {
                LearningDB.Add(userContent);
                await LearningDB.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public async void Respond(UserResponses userResponse)
        {
            try
            {
                LearningDB.Add(userResponse);
                await LearningDB.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public async void SetApproved(UserCourses userCourse)
        {
            userCourse.Approved = true;
            
            try
            {
                LearningDB.Update(userCourse);
                await LearningDB.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public async void SetComplete(UserCourses userCourse)
        {
            int completedTopics = 0;

            try
            {
                foreach (Topics topic in userCourse.Course.Topics)
                    if (IsComplete(LearningDB.Users.ToList().Find(u => u.Id == userCourse.UserId), topic))
                        completedTopics++;

                if (completedTopics == userCourse.Course.Topics.Count)
                {
                    userCourse.Completed = true;

                    LearningDB.Update(userCourse);
                    await LearningDB.SaveChangesAsync();
                }
                else
                {
                    userCourse.Completed = true;

                    LearningDB.Update(userCourse);
                    await LearningDB.SaveChangesAsync();
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async void SetComplete(UserContents userContent)
        {
            userContent.Completed = true;

            try
            {
                LearningDB.Update(userContent);
                await LearningDB.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
