using CaseStudy.Product.Domain.Providers;
using Microsoft.Extensions.Caching.Memory;

namespace CaseStudy.Product.Infra.Providers;

public class MemoryCacheProvider : ICacheProvider
{
    private readonly IMemoryCache _memoryCache;
    public MemoryCacheProvider(IMemoryCache memoryCache) { 
        _memoryCache = memoryCache;
    }

    public T Get<T>(string key) => _memoryCache.Get<T>(key);

    public void Set<T>(string key, T value, TimeSpan expireTime)
    {
        _memoryCache.Set(key, value, expireTime);
    }
    public void Delete(string key)
    {
        _memoryCache.Remove(key);
    }
}
