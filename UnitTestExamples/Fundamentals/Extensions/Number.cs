using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Extensions
{
    public static class Number
    {
        public static bool IsDivisbleBy(this int number, int divisor)
        {
            return number % divisor == 0;
        }
    }
}
