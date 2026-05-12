namespace DB_Project.Models;

public class Clinic
{
    public int ClinicID { get; set; }
    public string Location { get; set; } = string.Empty;
    public bool HasEmergencyFacilities { get; set; }
    public string Phone { get; set; } = string.Empty;
}
