namespace PeopleManager.Ui.Mvc.Models
{
    public class Person(string firstname,string lastname,string? email = null)
    {
        public string FirstName { get; set; } = firstname;
        public string LastName { get; set; } = lastname;
        public string? Email { get; set; } = email;
    }
}
