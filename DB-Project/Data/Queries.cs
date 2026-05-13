using Dapper;
using DB_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Project.Data;

public class Queries(DbConnectionFactory connectionFactory)
{
    public async Task<List<SpeciesVisitCount>> GetTopSpeciesAsync()
    {
        var query = @"
            SELECT TOP 1 P.species, COUNT(PV.visitID) AS VisitCount
            FROM PET P
            JOIN [PET VISIT] PV ON P.OwnerID = PV.ownerID AND P.petID = PV.petID
            JOIN [MEDICAL VISIT] MV ON PV.visitID = MV.visitID
            WHERE MONTH(MV.visitDate) = MONTH(DATEADD(month, -1, GETDATE())) 
              AND YEAR(MV.visitDate) = YEAR(DATEADD(month, -1, GETDATE()))
            GROUP BY P.species
            ORDER BY VisitCount DESC;";

        using var connection = connectionFactory.Create();
        var result = await connection.QueryAsync<SpeciesVisitCount>(query);
        return result.ToList();
    }

    public async Task<List<InactiveClinic>> GetInactiveClinicsAsync()
    {
        var query = @"
            SELECT C.clinicID, C.location
            FROM CLINIC C
            WHERE C.clinicID NOT IN (
                SELECT clinicID 
                FROM [MEDICAL VISIT] 
                WHERE MONTH(visitDate) = MONTH(DATEADD(month, -1, GETDATE())) 
                  AND YEAR(visitDate) = YEAR(DATEADD(month, -1, GETDATE()))
            );";

        using var connection = connectionFactory.Create();
        var result = await connection.QueryAsync<InactiveClinic>(query);
        return result.ToList();
    }

    public async Task<List<TopVaccinator>> GetTopVaccinatorAsync()
    {
        var query = @"
            SELECT TOP 1 V.vetID, V.name, COUNT(VAC.vaccinationID) AS VacCount
            FROM VETERINARIAN V
            JOIN [MEDICAL VISIT] MV ON V.visitID = MV.visitID
            JOIN VACCINATION VAC ON MV.visitID = VAC.visitID
            WHERE MONTH(MV.visitDate) = MONTH(DATEADD(month, -1, GETDATE())) 
              AND YEAR(MV.visitDate) = YEAR(DATEADD(month, -1, GETDATE()))
            GROUP BY V.vetID, V.name
            ORDER BY VacCount DESC;";

        using var connection = connectionFactory.Create();
        var result = await connection.QueryAsync<TopVaccinator>(query);
        return result.ToList();
    }

    public Task<List<InactiveOwner>> GetInactiveOwnersAsync() => throw new NotImplementedException();
    
    public Task<List<ClinicVaccine>> GetClinicVaccinesAsync() => throw new NotImplementedException();
    
    public Task<List<PetVisitSummary>> GetPetVisitsSummaryAsync() => throw new NotImplementedException();
}
