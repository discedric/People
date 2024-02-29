using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Core
{
    public class Database
    {
        public IList<Person> People { get; set; } = new List<Person>();

        public void Seed()
        {
            People = new List<Person>
            {
                new Person("John", "Doe", "john@example.com"),
                new Person("Jane", "Smith"),
                new Person("Michael", "Johnson", "michael@example.com"),
                new Person("Emily", "Brown"),
                new Person("William", "Taylor", "william@example.com"),
                new Person("Emma", "Anderson"),
                new Person("David", "Harris", "david@example.com"),
                new Person("Olivia", "Martin"),
                new Person("James", "Thompson", "james@example.com"),
                new Person("Sophia", "Garcia"),
                new Person("Daniel", "Wilson"),
                new Person("Ella", "Rodriguez", "ella@example.com"),
                new Person("Matthew", "Lee"),
                new Person("Amelia", "Martinez", "amelia@example.com"),
                new Person("Alexander", "Miller"),
                new Person("Ava", "Lopez"),
                new Person("Ryan", "White", "ryan@example.com"),
                new Person("Isabella", "Davis"),
                new Person("Samuel", "Gonzalez", "samuel@example.com"),
                new Person("Mia", "Wilson"),
                new Person("Nathan", "Moore", "nathan@example.com"),
                new Person("Abigail", "Jackson"),
                new Person("Nicholas", "Hill"),
                new Person("Charlotte", "Clark", "charlotte@example.com"),
                new Person("Brandon", "Lewis"),
                new Person("Grace", "Walker"),
                new Person("Hannah", "Young", "hannah@example.com"),
                new Person("Logan", "King"),
                new Person("Elizabeth", "Hall", "elizabeth@example.com"),
                new Person("Jacob", "Wright"),
                new Person("Zoe", "Adams"),
                new Person("Gabriel", "Green", "gabriel@example.com"),
                new Person("Liam", "Evans"),
                new Person("Madison", "Hill"),
                new Person("Benjamin", "Scott", "benjamin@example.com"),
                new Person("Lily", "Baker"),
                new Person("Jackson", "Rivera"),
                new Person("Chloe", "Nelson", "chloe@example.com"),
                new Person("Carter", "Carter"),
                new Person("Avery", "Perez"),
                new Person("Mason", "Roberts", "mason@example.com"),
                new Person("Evelyn", "Turner"),
                new Person("Elijah", "Phillips"),
                new Person("Sofia", "Mitchell", "sofia@example.com"),
                new Person("Harper", "Campbell"),
                new Person("Grayson", "Parker"),
                new Person("Victoria", "Morris", "victoria@example.com"),
                new Person("Aubrey", "Cook"),
                new Person("Joshua", "Bailey"),
                new Person("Eleanor", "Murphy", "eleanor@example.com"),
                new Person("Levi", "Reed")
            };
        }
    }
}
