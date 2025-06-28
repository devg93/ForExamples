using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Observer.Contracts;

namespace Observer.Cusomer
{
    public class CusomerC : IObserver
    {
        public void Event<T>(T value)
        {
          Console.WriteLine($"CusomerC received event with value: {value}");
        }
    }
}