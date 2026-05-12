namespace DB_Project.Models;

public class Veterinarian
{
    public int VetID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
}
