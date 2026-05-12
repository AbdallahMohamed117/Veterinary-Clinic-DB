namespace DB_Project.Models;

public class MedicalVisit
{
    public int VisitID { get; set; }
    public int ClinicID { get; set; }
    public int VetID { get; set; }
    public int OwnerID { get; set; }
    public int PetID { get; set; }
    public DateTime VisitDate { get; set; }
    public decimal WeightKg { get; set; }
    public string ClinicalNote { get; set; } = string.Empty;
}
