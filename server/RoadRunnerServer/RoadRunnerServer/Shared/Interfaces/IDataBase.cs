
using System.Collections.Generic;

namespace RoadRunnerServer.Shared
{
    public interface IDataBase<T> where T : IDbObject
    {
        T Read(object key);
        void Write(object key, T value);
        int Append(T value);

        T Remove(object key);

        IEnumerable<T> GetAll();

        //Task<T> ReadAsync(object key);
        //Task WriteAsync(object key, T value);
    }

    public interface IDbObject
    {
        int Id { get; set; }
    }
}
