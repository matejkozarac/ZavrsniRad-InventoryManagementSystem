using Microsoft.Extensions.Caching.Memory;
using PostSharp.Aspects;
using Serilog;
using System.Runtime.Caching;

namespace InventoryManagementSystem
{
    public class CachingAttribute : MethodInterceptionAspect
    {
        private readonly string cacheKey;
        private readonly int cacheDurationMinutes;

        public CachingAttribute(string cacheKey, int cacheDurationMinutes)
        {
            this.cacheKey = cacheKey;
            this.cacheDurationMinutes = cacheDurationMinutes;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            ObjectCache cache = new System.Runtime.Caching.MemoryCache("InventoryCache");

            var cachedResult = cache.Get(cacheKey);

            if (cachedResult != null)
            {
                args.ReturnValue = cachedResult;
                Log.Information($"Cache hit for key: {cacheKey}");
            }
            else
            {
                args.Proceed();

                cache.Add(cacheKey, args.ReturnValue, new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheDurationMinutes)
                });
                Log.Information($"Cache miss for key: {cacheKey}. Caching result.");
            }
        }
    }
}
