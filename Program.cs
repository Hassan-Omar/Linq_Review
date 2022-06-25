using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Review
{
    class Program
    {
        static void Main(string[] args)
        {
            // TO Do Here 
            Console.WriteLine("________________Partitioning________________");
            foreach (var element in Partitioning.nums)
            {
                Console.Write(element + "  ");
            }
            Console.WriteLine("");
            Partitioning.TakeN(5);
            Partitioning.TakeCriteria(x => x < 8);
            Partitioning.SkipN(2);
            Partitioning.SkipCriteria(x => x == 1);
            Console.WriteLine("________________Executions,Streaming________________");
            Execution_Streaming.ExecutionExample();
            Execution_Streaming.Stream_Or_Non_Example();
            Console.ReadLine();
        }
    }

    static class Partitioning
    {
        public static int[] nums = { 4, 2, 3, 1, 5, 6, 8, 7, 9, 10 };

        public static void TakeN(int n)
        {
            Console.WriteLine("Take({0})", n);
            nums.Take(n).ToList().ForEach(item => {
                Console.Write(item + " ");
            });
            Console.WriteLine("");
        }
        public static void TakeCriteria(Func<int, bool> predicate)
        {
            Console.WriteLine("TakeCriteria(predicate)");
            nums.TakeWhile(predicate).ToList().ForEach(item => {
                Console.Write(item + " ");
            });
            Console.WriteLine("");
        }

        public static void SkipN(int n)
        {
            Console.WriteLine("Skip({0})", n);
            nums.Skip(n).ToList().ForEach(item => {
                Console.Write(item + " ");
            });
            Console.WriteLine("");
        }
        public static void SkipCriteria(Func<int, bool> predicate)
        {
            Console.WriteLine("SkipCriteria(predicate)");
            nums.SkipWhile(predicate).ToList().ForEach(item => {
                Console.Write(item + " ");
            });
            Console.WriteLine("");
        }
    }

    public static class Execution_Streaming
    {
        public static void ExecutionExample()
        {
            Console.WriteLine("nums.Count(), nums.ToList() both return {value} => they are Immediate Execution");
            Console.WriteLine("nums.Select(), nums.Where() both return {IEnumerable<T> or IQueryable<T>} => they are Defred Execution");
            Console.WriteLine("");
        }
        public static void Stream_Or_Non_Example()
        {
            Console.WriteLine("Stream Example => Select,Where,.....");
            var lst = new List<int>() { 3, 5, 1, 2 };
            var streamingQuery = lst.Select(x => {
                Console.WriteLine(x);
                return x;
            });
            foreach (var i in streamingQuery)
            {
                Console.WriteLine($"foreach iteration value: {i}");
            }
            Console.WriteLine("None Stream Example => OrderBy,GroupBy,.....");
            var nonStreamingQuery = lst.OrderBy(x => {
                Console.WriteLine(x);
                return x;
            });
            foreach (var i in nonStreamingQuery)
            {
                Console.WriteLine($"foreach iteration value: {i}");
            }
            Console.WriteLine("");
        }
    }
}
