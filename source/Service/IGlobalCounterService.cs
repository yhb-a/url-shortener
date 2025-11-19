using System.Diagnostics.Metrics;
using URLShortener.Repository;

namespace URLShortener.Service
{
    public interface IGlobalCounterService
    {
        void SetCounter(int latestId);
        void Increment();
        int GetCurrentCount();
    }
}
