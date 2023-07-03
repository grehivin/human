using BackEnd.dal.entities;

namespace FrontEnd.Models
{
    public class StudentViewModel
    {
        public Persons Person { get; set; }
        public Users User { get; set; }

        public StudentViewModel()
        {
            Person = new Persons();
            User = new Users();
        }

        public StudentViewModel(Persons person, Users user)
        {
            Person = person;
            User = user;
        }
    }
}
