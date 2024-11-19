using medipro_patient_service.Application.DTO;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.Redis;
using medipro_patient_service.Application.Interfaces.Repositories;
using Medipro_Patient_Service.Common.Utilities;
using medipro_patient_service.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace medipro_patient_service.Application.Helper;

public class UserDetailsHelper(
    IHttpContextAccessor httpContextAccessor,
    IRedisCachedService redisCachedService,
    IGenericRepository<Patient> repo) : IUserDetailsHelper
{
    // public UserDetailsHelper() : this()
    // {}
    //
    public  UserDetail GetUserDetail()
    {
        var context = httpContextAccessor.HttpContext;
        if (context is not null && context.Items.TryGetValue("UserDetails", out var item))
            return (UserDetail)item!;
        return null;
    }

    public async Task<string?> GetMedHistoryId()
    {
        var userId = GetUserDetail().UserId;
        var key = $"{userId}-medHisId";
        var medHistoryId = await redisCachedService.GetData<string>(key);
        if (medHistoryId is not null)
            return medHistoryId;
        var patient = await repo.FindAndIncludeAsync(p => p.UserId == userId, "MedicalHistory", "Contact");
        var pat = patient.FirstOrDefault(p => p.UserId == userId);
        medHistoryId = pat?.MedicalHistory?.Id.ToString();
        await redisCachedService.SetData(key, medHistoryId);
        return medHistoryId;
    }
    public async Task<string?> GetPastMedHistoryId()
    {
        var userId = GetUserDetail().UserId;
        var key = $"{userId}-pastMedHisId";
        var pastMedHistoryId = await redisCachedService.GetData<string>(key);
        if (pastMedHistoryId is not null)
            return pastMedHistoryId;
        var patient = await repo.FindAndIncludeAsync(p => p.UserId == userId, "PastMedicalHistory");
        var pat = patient.FirstOrDefault(p => p.UserId == userId);
        pastMedHistoryId = pat?.PastMedicalHistory?.Id.ToString();
        await redisCachedService.SetData(key, pastMedHistoryId);
        return pastMedHistoryId;
    }

    public async Task<string> GetPatientId()
    {
        var userId = GetUserDetail().UserId;
        var key = $"{userId}-patientId";
        var patientId = await redisCachedService.GetData<string>(key);
        if (patientId is not null)
            return patientId;
        var patient = await repo.FindAsync(p => p.UserId == userId);
        await redisCachedService.SetData(key, patient?.Id.ToString());
        return patient is not null ? patient.Id.ToString() : throw new Exception(TaskMessage.ExpMessage);
    }

    // public async Task<string> GetJwtTokenAsync(string url, string clientId, string username, string password,
    //     string clientSecret = null)
    // {
    //     
    // }
}