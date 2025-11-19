using URLShortener.Models;

namespace URLShortener.Service
{
    public interface IURLService
    {
        Task<string> ShortenCode(string longURL);
        Task<string> GetLongUrl(string shortCode);
        Task Delete(string shortCode);
        Task UpdateLongUrl(string shortCode, string longURL);
        Task IncrementAccessCount(string shortCode);
        Task<int> GetAccessCount(string  shortCode);
        void DeleteAll();
    }
}
