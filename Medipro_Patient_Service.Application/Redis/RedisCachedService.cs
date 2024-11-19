using System.Text.Json;
using medipro_patient_service.Application.Interfaces.Redis;
using Microsoft.Extensions.Caching.Distributed;

namespace medipro_patient_service.Application.Redis;

public class RedisCachedService : IRedisCachedService
{
    private readonly IDistributedCache? _distributedCache;

    public RedisCachedService(IDistributedCache? distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public RedisCachedService()
    {
    }

    public async Task<T?> GetData<T>(string key)
    {
        var data = await _distributedCache?.GetStringAsync(key)!;
        return data is null ? default(T) : JsonSerializer.Deserialize<T>(data);
    }

    public async Task SetData<T>(string key, T data)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(300)
        };
        await _distributedCache?.SetStringAsync(key, JsonSerializer.Serialize(data), options)!;
    }
}