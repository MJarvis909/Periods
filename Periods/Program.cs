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

            list.Sort((x, y) => x.Start.CompareTo(y.Start)); //sorting list of periods

            var stack = new Stack<Period>();

            foreach (var CurrentStack in list) //Pushing list into stack merging overlaping periods
            {
                switch (stack.Count)             
                {
                    case 0:
                        stack.Push(CurrentStack);
                        break;

                    default:
                
                        var LastStack = stack.Peek();

                        if (LastStack.Stop >= CurrentStack.Start && LastStack.Stop <= CurrentStack.Stop)
                        {
                            int popedPeriod = LastStack.Start;
                            stack.Pop();
                            stack.Push(new Period(popedPeriod, CurrentStack.Stop));
                        }
                        if (LastStack.Stop >= CurrentStack.Start && LastStack.Stop > CurrentStack.Stop)
                        {
                            break;
                        }
                        else if (LastStack.Stop < CurrentStack.Start)
                        {
                            stack.Push(CurrentStack);
                        }
                        break;
                }
            }
            list.Clear(); //cleaing the list

            foreach (var period in stack) //Adding periods from list to stack
            {
                list.Add(period);
            }

            list.Reverse(); //Reversing the list

            foreach (var period in list) //Displaying list of periods
            {
                Console.WriteLine(period.Start + " " + period.Stop);
            }

            Console.ReadKey();
        }
    }
}
