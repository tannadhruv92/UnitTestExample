using Fundamentals.Extensions;

namespace Fundamentals.WithoutMoq
{
    public class FizzBuzz
    {
        public string GetOutPut(int number)
        {
            if (number.IsDivisbleBy(3) && number.IsDivisbleBy(5))
                return "FizzBuzz";
            if(number.IsDivisbleBy(3))
                return "Fizz";
            if(number.IsDivisbleBy(5))
                return "Buzz";

            return number.ToString();
        }
    }
}
