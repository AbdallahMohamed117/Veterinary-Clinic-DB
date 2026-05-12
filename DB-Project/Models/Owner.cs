namespace DB_Project.Models;

public class Owner
{
    public int OwnerID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BillingAddress { get; set; } = string.Empty;
    public string EmergencyContact { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
