namespace DB_Project.Models;

public class Pet
{
    public int OwnerID { get; set; }
    public int PetID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
}
