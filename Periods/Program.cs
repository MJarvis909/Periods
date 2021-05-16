using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periods
{
    public class Period
    {
        public int Start { get; }
        public int Stop { get; }

        public Period(int start, int stop)
        {
            Start = start;
            Stop = stop;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Period> //Creating list of periods
            {
                new Period(1, 3),
                new Period(1, 4),
                new Period(2, 3),
                new Period(5, 7),
                new Period(17, 23),
                new Period(15, 20),
                new Period(24, 27),
                new Period(25, 30)
            };

            list.OrderBy(x => x.Start); //sorting list of periods

            var stack = new Stack<Period>();

            foreach (var period in list) //Pushing list into stack merging overlaping periods
            {

                if (stack.Count == 0)
                {
                    stack.Push(period);

                }
                else
                {
                    var LastStack = stack.Peek();

                    if (LastStack.Stop >= period.Start && LastStack.Stop <= period.Stop)
                    {
                        int popedPeriod = LastStack.Start;
                        stack.Pop();
                        stack.Push(new Period(popedPeriod, period.Stop));
                    }
                    //if (LastStack.Stop >= period.Start && LastStack.Stop > period.Stop)
                    else if (LastStack.Stop < period.Start)
                    {
                        stack.Push(period);
                    }
                } 
            }
            //list.Clear(); //cleaing the list -- Don't reuse lists

            var results = new List<Period>();

            foreach (var period in stack) //Adding periods from stack to list
            {
                results.Add(period);
            }

            results.Reverse(); //Reversing the list

            foreach (var period in results) //Displaying list of periods
            {
                Console.WriteLine(period.Start + " " + period.Stop);
            }

        }
    }
}
