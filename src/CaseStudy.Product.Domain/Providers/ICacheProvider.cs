namespace CaseStudy.Product.Domain.Providers;

public interface ICacheProvider 
{
    T Get<T>(string key);
    void Set<T>(string key, T value, TimeSpan expireTime);
    void Delete(string key);
}
