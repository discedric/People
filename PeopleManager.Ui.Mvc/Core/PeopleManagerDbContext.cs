using Microsoft.EntityFrameworkCore;
using PeopleManager.Ui.Mvc.Models;
using System.Collections.Generic;

namespace PeopleManager.Ui.Mvc.Core
{
    public class PeopleManagerDbContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();

        public PeopleManagerDbContext(DbContextOptions<PeopleManagerDbContext> options) : base(options)
        {

        }

        public void Seed()
        {
            var people = new List<Person>
            {
                new() {FirstName= "John",LastName= "Doe", Email = "john@example.com"},
                new(){FirstName = "Jane",LastName = "Smith"},
                new(){FirstName = "Michael", LastName = "Johnson", Email = "michael@example.com"},
                new() {FirstName = "Emily", LastName = "Brown"},
                new() {FirstName = "William", LastName = "Taylor", Email = "william@example.com"},
                new() {FirstName = "Emma", LastName = "Anderson"},
                new() {FirstName = "David", LastName = "Harris", Email = "david@example.com"},
                new() {FirstName = "Olivia", LastName = "Martin"},
                new() {FirstName = "James", LastName = "Thompson", Email = "james@example.com"},
                new() {FirstName = "Sophia", LastName = "Garcia"},
                new() {FirstName = "Daniel", LastName = "Wilson"},
                new() {FirstName = "Ella", LastName = "Rodriguez", Email = "ella@example.com"},
                new() {FirstName = "Matthew", LastName = "Lee"},
                new() {FirstName = "Amelia", LastName = "Martinez", Email = "amelia@example.com"},
                new() {FirstName = "Alexander", LastName = "Miller"},
                new() {FirstName = "Ava", LastName = "Lopez"},
                new() {FirstName = "Ryan", LastName = "White", Email = "ryan@example.com"},
                new() {FirstName = "Isabella", LastName = "Davis"},
                new() {FirstName = "Samuel", LastName = "Gonzalez", Email = "samuel@example.com"},
                new() {FirstName = "Mia", LastName = "Wilson"},
                new() {FirstName = "Nathan", LastName = "Moore", Email = "nathan@example.com"},
                new() {FirstName = "Abigail", LastName = "Jackson"},
                new() {FirstName = "Nicholas", LastName = "Hill"},
                new() {FirstName = "Charlotte", LastName = "Clark", Email = "charlotte@example.com"},
                new() {FirstName = "Brandon", LastName = "Lewis"},
                new() {FirstName = "Grace", LastName = "Walker"},
                new() {FirstName = "Hannah", LastName = "Young", Email = "hannah@example.com"},
                new() {FirstName = "Logan", LastName = "King"},
                new() {FirstName = "Elizabeth", LastName = "Hall", Email = "elizabeth@example.com"},
                new() {FirstName = "Jacob", LastName = "Wright"},
                new() {FirstName = "Zoe", LastName = "Adams"},
                new() {FirstName = "Gabriel", LastName = "Green", Email = "gabriel@example.com"},
                new() {FirstName = "Liam", LastName = "Evans"},
                new() {FirstName = "Madison", LastName = "Hill"},
                new() {FirstName = "Benjamin", LastName = "Scott", Email = "benjamin@example.com"},
                new() {FirstName = "Lily", LastName = "Baker"},
                new() {FirstName = "Jackson", LastName = "Rivera"},
                new() {FirstName = "Chloe", LastName = "Nelson", Email = "chloe@example.com"},
                new() {FirstName = "Carter", LastName = "Carter"},
                new() {FirstName = "Avery", LastName = "Perez"},
                new() {FirstName = "Mason", LastName = "Roberts", Email = "mason@example.com"},
                new() {FirstName = "Evelyn", LastName = "Turner"},
                new() {FirstName = "Elijah", LastName = "Phillips"},
                new() {FirstName = "Sofia", LastName = "Mitchell", Email = "sofia@example.com"},
                new() {FirstName = "Harper", LastName = "Campbell"},
                new() {FirstName = "Grayson", LastName = "Parker"},
                new() {FirstName = "Victoria", LastName = "Morris", Email = "victoria@example.com"},
                new() {FirstName = "Aubrey", LastName = "Cook"},
                new() {FirstName = "Joshua", LastName = "Bailey"},
                new() {FirstName = "Eleanor", LastName = "Murphy", Email = "eleanor@example.com"},
                new() {FirstName = "Levi", LastName = "Reed"}
            };
            People.AddRange(people);
            SaveChanges();
        }
    }
}
