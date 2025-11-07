using URLShortener.Models;
using URLShortener.Repository;
using URLShortener.Utilities;

namespace URLShortener.Service
{
    public class URLService : IURLService
    {
        IURLRepository uRLRepository;
        IGlobalCounterService globalCounter; 

        public URLService(
            IURLRepository uRLRepository, 
            IGlobalCounterService globalCounter)
        {
            this.uRLRepository = uRLRepository;
            this.globalCounter = globalCounter;
        }

        public async Task<string> ShortenCode(string longURL)
        {
            var shortCode = ShortCodeHelper.GetShortCode(this.globalCounter.GetCurrentCount());

            var mapping = new Url()
            {
                Id = this.globalCounter.GetCurrentCount(),
                ShortCode = shortCode,
                LongUrl = longURL,
                CreatedAt = DateTime.UtcNow,
            };

            await this.uRLRepository.AddURL(mapping);

            this.globalCounter.Increment();

            return shortCode;
        }

        public async Task<string> GetLongUrl(string shortCode)
        {
            return await this.uRLRepository.GetLongURL(shortCode);
        }
        
        public async Task Delete(string shortCode)
        {
            await this.uRLRepository.Delete(shortCode);
        }

        public async Task UpdateLongUrl(string shortCode, string longURL)
        {
            await this.uRLRepository.UpdateLongUrl(shortCode, longURL);
        }

        public async Task IncrementAccessCount(string shortCode)
        {
            await this.uRLRepository.UpdateAccessCount(shortCode);
        }

        public async Task<int> GetAccessCount(string shortCode)
        {
            return await this.uRLRepository.GetAccessCount(shortCode);
        }

        public void DeleteAll()
        {
            this.uRLRepository.DeleteAll();
        }
    }
}
