using Microsoft.EntityFrameworkCore;
using PeopleManager.Model;

namespace PeopleManager.Core
{
    public class PeopleManagerDbContext(DbContextOptions<PeopleManagerDbContext> options) : DbContext(options)
    {
        public DbSet<Person> People => Set<Person>();
        public DbSet<Organization> Organizations => Set<Organization>();

        public void Seed()
        {
            var vivesOrg = new Organization()
            {
                Name = "Vives international collage"
            };
            Organizations.Add(vivesOrg);
            var Youthorg = new Organization()
            {
                Name = "Young Blood Youth Group"
            };
            Organizations.Add(Youthorg);
            var people = new List<Person>
            {
                new() {FirstName= "John",LastName= "Doe", Email = "john@example.com", Organization = Youthorg},
                new() {FirstName = "Jane",LastName = "Smith", Organization = vivesOrg},
                new() {FirstName = "Michael", LastName = "Johnson", Email = "michael@example.com"},
                new() {FirstName = "Emily", LastName = "Brown", Organization = vivesOrg},
                new() {FirstName = "William", LastName = "Taylor", Email = "william@example.com"},
                new() {FirstName = "Emma", LastName = "Anderson"},
                new() {FirstName = "David", LastName = "Harris", Email = "david@example.com", Organization = Youthorg},
                new() {FirstName = "Olivia", LastName = "Martin"},
                new() {FirstName = "James", LastName = "Thompson", Email = "james@example.com", Organization = vivesOrg},
                new() {FirstName = "Sophia", LastName = "Garcia"},
                new() {FirstName = "Daniel", LastName = "Wilson", Organization = Youthorg},
                new() {FirstName = "Ella", LastName = "Rodriguez", Email = "ella@example.com"},
                new() {FirstName = "Matthew", LastName = "Lee", Organization = vivesOrg},
                new() {FirstName = "Amelia", LastName = "Martinez", Email = "amelia@example.com"},
                new() {FirstName = "Alexander", LastName = "Miller", Organization = Youthorg},
                new() {FirstName = "Ava", LastName = "Lopez"},
                new() {FirstName = "Ryan", LastName = "White", Email = "ryan@example.com", Organization = vivesOrg},
                new() {FirstName = "Isabella", LastName = "Davis"},
                new() {FirstName = "Samuel", LastName = "Gonzalez", Email = "samuel@example.com", Organization = Youthorg},
                new() {FirstName = "Mia", LastName = "Wilson"},
                new() {FirstName = "Nathan", LastName = "Moore", Email = "nathan@example.com", Organization = vivesOrg},
                new() {FirstName = "Abigail", LastName = "Jackson"},
                new() {FirstName = "Nicholas", LastName = "Hill", Organization = Youthorg},
                new() {FirstName = "Charlotte", LastName = "Clark", Email = "charlotte@example.com"},
                new() {FirstName = "Brandon", LastName = "Lewis", Organization = vivesOrg},
                new() {FirstName = "Grace", LastName = "Walker"},
                new() {FirstName = "Hannah", LastName = "Young", Email = "hannah@example.com", Organization = Youthorg},
                new() {FirstName = "Logan", LastName = "King"},
                new() {FirstName = "Elizabeth", LastName = "Hall", Email = "elizabeth@example.com", Organization = vivesOrg},
                new() {FirstName = "Jacob", LastName = "Wright"},
                new() {FirstName = "Zoe", LastName = "Adams", Organization = Youthorg},
                new() {FirstName = "Gabriel", LastName = "Green", Email = "gabriel@example.com"},
                new() {FirstName = "Liam", LastName = "Evans", Organization = vivesOrg},
                new() {FirstName = "Madison", LastName = "Hill"},
                new() {FirstName = "Benjamin", LastName = "Scott", Email = "benjamin@example.com", Organization = Youthorg},
                new() {FirstName = "Lily", LastName = "Baker"},
                new() {FirstName = "Jackson", LastName = "Rivera", Organization = vivesOrg},
                new() {FirstName = "Chloe", LastName = "Nelson", Email = "chloe@example.com"},
                new() {FirstName = "Carter", LastName = "Carter", Organization = Youthorg},
                new() {FirstName = "Avery", LastName = "Perez"},
                new() {FirstName = "Mason", LastName = "Roberts", Email = "mason@example.com", Organization = vivesOrg},
                new() {FirstName = "Evelyn", LastName = "Turner"},
                new() {FirstName = "Elijah", LastName = "Phillips", Organization = Youthorg},
                new() {FirstName = "Sofia", LastName = "Mitchell", Email = "sofia@example.com"},
                new() {FirstName = "Harper", LastName = "Campbell", Organization = vivesOrg},
                new() {FirstName = "Grayson", LastName = "Parker"},
                new() {FirstName = "Victoria", LastName = "Morris", Email = "victoria@example.com", Organization = Youthorg},
                new() {FirstName = "Aubrey", LastName = "Cook"},
                new() {FirstName = "Joshua", LastName = "Bailey", Organization = vivesOrg},
                new() {FirstName = "Eleanor", LastName = "Murphy", Email = "eleanor@example.com"},
                new() {FirstName = "Levi", LastName = "Reed", Organization = Youthorg}
            };

            People.AddRange(people);
            SaveChanges();
        }
    }
}
