using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;

using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Services
{
    public class DataBase<T> : IDataBase<T> where T : IDbObject
    {
        private readonly IMemoryCache _cache;

        private readonly string _prefix; 
        //private static readonly IDictionary<object, object> _cache = new Dictionary<object, object>();
        //private readonly ILogger _logger;

        public DataBase(IMemoryCache cache /*, ILogger logger/*, IConfiguration config*/)
        {
            _cache = cache;
            _prefix = typeof(T).Name;
            //_logger = logger;
        }
        public T Read(object key)
        {
            try
            {
                if (_cache.TryGetValue($"{_prefix}:{key}", out var obj))
                    return (T) obj;

                //if(_cache.ContainsKey(key))
                //    return (T)_cache[key];
                return default(T);
            }
            catch (Exception ex)
            {
                Trace.Write($"Error reading '{key}' from DB type '{GetType().Name}'\n => {ex.ToString()}");
                //_logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }

        public void Write(object key, T value)
        {
            try
            {
                //_cache[key]  = value;
                _cache.Set($"{_prefix}:{key}", value);
            }
            catch (Exception ex)
            {
                Trace.Write($"Error saving '{key}' => {value} to '{GetType().Name}'\n => {ex.ToString()}");
                //_logger.Log(LogLevel.Error, ex.Message);
            }
        }

        public int Append(T value)
        {
            var autoKey = 1;
            var allItems = GetAll();
            if (allItems.Any())
            {
                autoKey = GetAll().Max(o => o.Id) + 1;
            }

            value.Id = autoKey;
            
            Write(autoKey, value);

            return autoKey;
        }

        public T Remove(object key)
        {
            try
            {
                _cache.TryGetValue($"{_prefix}:{key}", out var value);
                _cache.Remove(key);
                //var value = Read(key);
                //if (value != null)
                //    _cache.Remove(key);
                //
                return (T) value;
            }
            catch (Exception ex)
            {
                Trace.Write($"Error removing '{key}' => {key} to '{GetType().Name}'\n => {ex.ToString()}");
                //_logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            //return _cache.Values.OfType<T>();
            return GetAllKeys().Select(Read);
        }

        private IEnumerable<string> GetAllKeys()
        {
            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);

            if (!(field.GetValue(_cache) is ICollection collection))
                yield break;

            var prefix = $"{_prefix}:";

            foreach (var item in collection)
            {
                var methodInfo = item.GetType().GetProperty("Key");
                var key = methodInfo.GetValue(item).ToString();
                if(key.StartsWith(prefix))
                    yield return key.Substring(prefix.Length);
            }
        }
    }

}
