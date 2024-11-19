using medipro_patient_service.Application.DTO;

namespace Medipro_Patient_Service.Application.Interfaces.Helper;

public interface IUserDetailsHelper
{
    UserDetail GetUserDetail();
    Task<string?> GetMedHistoryId();
    Task<string?> GetPastMedHistoryId();
    Task<string> GetPatientId();
}