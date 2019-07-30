using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using RoadRunnerServer.Shared;
using RoadRunnerServer.Shared.Interfaces;

namespace RoadRunnerServer.Services
{
    public class DataBase<T> : IDataBase<T>
    {
        //private readonly IMemoryCache _cache;
        private static readonly IDictionary<object, object> _cache = new Dictionary<object, object>();



        //private readonly ILogger _logger;
        //private string _connectionString;

        //public DataBase(IMemoryCache cache /*, ILogger logger/*, IConfiguration config*/)
        //{
        //    _cache = cache;
        //    //_logger = logger;
        //}
        public T Read(object key)
        {
            try
            {
                if(_cache.ContainsKey(key))
                    return (T)_cache[key];
                return default(T);
            }
            catch (Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }

        public void Write(object key, T value)
        {
            try
            {
                _cache[key]  = value;
            }
            catch (Exception ex)
            {
                Trace.Write($"Error saving '{key}' => {value} to '{GetType().Name}'");
                //_logger.Log(LogLevel.Error, ex.Message);
            }
        }

        public T Remove(object key)
        {
            try
            {
                var value = Read(key);
                if (value != null)
                    _cache.Remove(key);

                return (T)value;
            }
            catch (Exception ex)
            {
                Trace.Write($"Error removing '{key}' => {key} to '{GetType().Name}'");
                //_logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _cache.Values.OfType<T>();
        }
    }

}
