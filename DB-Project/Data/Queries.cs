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
            SELECT TOP 1 P.species, COUNT(MV.visitID) AS VisitCount
            FROM PET P
            JOIN MEDICAL_VISIT MV ON P.ownerID = MV.ownerID AND P.petID = MV.petID
            WHERE MONTH(MV.visitDate) = MONTH(DATEADD(month, -1, GETDATE())) 
              AND YEAR(MV.visitDate) = YEAR(DATEADD(month, -1, GETDATE()))
            GROUP BY P.species
            ORDER BY VisitCount DESC;";

        using var connection = connectionFactory.Create();
        await connection.OpenAsync();
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
                FROM MEDICAL_VISIT 
                WHERE MONTH(visitDate) = MONTH(DATEADD(month, -1, GETDATE())) 
                  AND YEAR(visitDate) = YEAR(DATEADD(month, -1, GETDATE()))
            );";

        using var connection = connectionFactory.Create();
        await connection.OpenAsync();
        var result = await connection.QueryAsync<InactiveClinic>(query);
        return result.ToList();
    }

    public async Task<List<TopVaccinator>> GetTopVaccinatorAsync()
    {
        var query = @"
            SELECT TOP 1 V.vetID, V.name, COUNT(VAC.vaccinationID) AS VaccinationCount
            FROM VETERINARIAN V
            JOIN MEDICAL_VISIT MV ON V.vetID = MV.vetID
            JOIN VACCINATION VAC ON MV.visitID = VAC.visitID
            WHERE MONTH(MV.visitDate) = MONTH(DATEADD(month, -1, GETDATE())) 
              AND YEAR(MV.visitDate) = YEAR(DATEADD(month, -1, GETDATE()))
            GROUP BY V.vetID, V.name
            ORDER BY VaccinationCount DESC;";

        using var connection = connectionFactory.Create();
        await connection.OpenAsync();
        var result = await connection.QueryAsync<TopVaccinator>(query);
        return result.ToList();
    }

    public async Task<List<InactiveOwner>> GetInactiveOwnersAsync()
    {
        var query = @"
            SELECT O.ownerID, O.name, O.email
            FROM OWNER O
            WHERE O.ownerID NOT IN (
                SELECT DISTINCT ownerID
                FROM MEDICAL_VISIT
                WHERE MONTH(visitDate) = MONTH(DATEADD(month, -1, GETDATE())) 
                  AND YEAR(visitDate) = YEAR(DATEADD(month, -1, GETDATE()))
            );";

        using var connection = connectionFactory.Create();
        await connection.OpenAsync();
        var result = await connection.QueryAsync<InactiveOwner>(query);
        return result.ToList();
    }

    public async Task<List<ClinicVaccine>> GetClinicVaccinesAsync()
    {
        var query = @"
            SELECT C.clinicID, C.location, VAC.vaccineType, VAC.batchNumber, MV.visitDate
            FROM CLINIC C
            JOIN MEDICAL_VISIT MV ON C.clinicID = MV.clinicID
            JOIN VACCINATION VAC ON MV.visitID = VAC.visitID
            WHERE MONTH(MV.visitDate) = MONTH(DATEADD(month, -1, GETDATE())) 
              AND YEAR(MV.visitDate) = YEAR(DATEADD(month, -1, GETDATE()))
            ORDER BY C.clinicID, MV.visitDate;";

        using var connection = connectionFactory.Create();
        await connection.OpenAsync();
        var result = await connection.QueryAsync<ClinicVaccine>(query);
        return result.ToList();
    }

    public async Task<List<PetVisitSummary>> GetPetVisitsSummaryAsync()
    {
        var query = @"
            SELECT P.ownerID, P.petID, P.name AS PetName, COUNT(MV.visitID) AS VisitCount
            FROM PET P
            LEFT JOIN MEDICAL_VISIT MV ON P.ownerID = MV.ownerID AND P.petID = MV.petID
                AND YEAR(MV.visitDate) = YEAR(GETDATE())
            GROUP BY P.ownerID, P.petID, P.name
            ORDER BY P.ownerID, P.petID;";

        using var connection = connectionFactory.Create();
        await connection.OpenAsync();
        var result = await connection.QueryAsync<PetVisitSummary>(query);
        return result.ToList();
    }
}
