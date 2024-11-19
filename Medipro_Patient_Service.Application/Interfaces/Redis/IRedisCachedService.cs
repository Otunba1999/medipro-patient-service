namespace medipro_patient_service.Application.Interfaces.Redis;

public interface IRedisCachedService
{
    Task<T?> GetData<T>(string key);
    Task SetData<T>(string key, T data);
}