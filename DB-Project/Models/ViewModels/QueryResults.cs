namespace DB_Project.Models.ViewModels;

public class SpeciesVisitCount
{
    public string Species { get; set; } = string.Empty;
    public int VisitCount { get; set; }
}

public class InactiveClinic
{
    public int ClinicID { get; set; }
    public string Location { get; set; } = string.Empty;
}

public class TopVaccinator
{
    public int VetID { get; set; }
    public string Name { get; set; } = string.Empty;
    public int VaccinationCount { get; set; }
}

public class InactiveOwner
{
    public int OwnerID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class ClinicVaccine
{
    public int ClinicID { get; set; }
    public string Location { get; set; } = string.Empty;
    public string VaccineType { get; set; } = string.Empty;
    public string BatchNumber { get; set; } = string.Empty;
    public DateTime VisitDate { get; set; }
}

public class PetVisitSummary
{
    public int OwnerID { get; set; }
    public int PetID { get; set; }
    public string PetName { get; set; } = string.Empty;
    public int VisitCount { get; set; }
}
