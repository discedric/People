namespace PeopleManager.Ui.Mvc.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
