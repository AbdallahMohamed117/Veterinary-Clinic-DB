namespace DB_Project.Models;

public class Vaccination
{
    public int VaccinationID { get; set; }
    public int VisitID { get; set; }
    public string VaccineType { get; set; } = string.Empty;
    public string BatchNumber { get; set; } = string.Empty;
    public DateTime BoosterDueDate { get; set; }
}
