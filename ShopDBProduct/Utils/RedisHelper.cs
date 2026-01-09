using StackExchange.Redis;

namespace ShopDBProduct.Utils
{
    public class RedisHelper
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        public RedisHelper(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _db = redis.GetDatabase();
        }

        public async Task<string?> GetValueAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }

        public async Task SetValueAsync(string key, string value, TimeSpan? expiry = null)
        {
            if (expiry.HasValue)
                await _db.StringSetAsync(key, value, expiry.Value);
            else
                await _db.StringSetAsync(key, value);
        }

        // Thực hiện Redis Lock
        public async Task<bool> TryAcquireLockAsync(string lockKey, string value, TimeSpan expiry)
        {
            return await _db.LockTakeAsync(lockKey, value, expiry);
        }

        // Giải phóng Redis Lock
        public async Task ReleaseLockAsync(string lockKey, string value)
        {
            await _db.LockReleaseAsync(lockKey, value);
        }

        // Kiểm tra xem key có tồn tại trong Redis không
        public async Task<bool> KeyExistsAsync(string key)
        {
            return await _db.KeyExistsAsync(key);
        }
    }
}
