using DB_Project.Models.ViewModels;

namespace DB_Project.Data;

public class Queries(DbConnectionFactory connectionFactory)
{
    public Task<List<SpeciesVisitCount>> GetTopSpeciesAsync() => throw new NotImplementedException();
    public Task<List<InactiveClinic>> GetInactiveClinicsAsync() => throw new NotImplementedException();
    public Task<List<TopVaccinator>> GetTopVaccinatorAsync() => throw new NotImplementedException();
    public Task<List<InactiveOwner>> GetInactiveOwnersAsync() => throw new NotImplementedException();
    public Task<List<ClinicVaccine>> GetClinicVaccinesAsync() => throw new NotImplementedException();
    public Task<List<PetVisitSummary>> GetPetVisitSummaryAsync() => throw new NotImplementedException();
}
