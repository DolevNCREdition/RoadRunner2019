
using System.Collections.Generic;

namespace RoadRunnerServer.Shared.Interfaces
{
    public interface IDataBase<T>
    {
        T Read(object key);
        void Write(object key, T value);
        int Append(T orderLine);

        T Remove(object key);

        IEnumerable<T> GetAll();

        //Task<T> ReadAsync(object key);
        //Task WriteAsync(object key, T value);
    }
}
