using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Observer.Contracts;

namespace Observer.Cusomer
{
    public class CusomerB : IObserver
    {
        public void Event<T>(T value)
        {
            Console.WriteLine($"CusomerB received event with value: {value}");
        }
    }
}