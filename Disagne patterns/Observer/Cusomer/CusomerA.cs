using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Observer.Contracts;

namespace Observer.Cusomer
{
    public class CusomerA : IObserver
    {
        public void Event<T>(T value)
        {
           Console.WriteLine($"CusomerA received event with value: {value}");
        }
    }
}