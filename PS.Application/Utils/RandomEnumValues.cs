using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Application.Utils
{
    public class RandomEnumValues
    {
        static Random _R = new Random();
        public T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }
    }
}
