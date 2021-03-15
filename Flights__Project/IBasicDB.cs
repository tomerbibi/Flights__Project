using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public interface IBasicDB<T> where T : IPoco
    {
        void Add(T t);
        T Get(long id);
        List<T> GetAll();
        void Remove(T t);
        void Update(T t);
    }
}
