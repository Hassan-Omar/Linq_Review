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
            Console.WriteLine("________________Concatenation________________");
            int[] a = { 1, 2, 3 };
            int[] b = { 4, 5, 6 };
            Concatenation.Concate(a, b);
            Console.WriteLine("________________Filtering________________");
            Filtering.Where(Enumerable.Range(1,10).ToArray(), x => x>4);
            Filtering.OfType(Enumerable.Range(1,10).ToArray()); 
            Console.WriteLine("________________grouping________________");
            Grouping grouping = new Grouping();
            grouping.Init();
            grouping.Join();
            grouping.GroupJoin();
            grouping.ZIP(); 
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

    public static class Concatenation
    {
        public static void Concate(int[] a, int[] b)
        {
            Console.WriteLine("Concate");
            a.Concat(b).ToList().ForEach(item =>
            {
                Console.Write(item + " ");
            });
            Console.WriteLine("");
        }
    }
    public static class Filtering
    {
        public static void Where(int[] nums, Func<int, bool> filterOption)
        {
            Console.WriteLine("Where");
            nums.Where(filterOption).ToList().ForEach(item =>
            {
                Console.Write(item + " ");
            });
            Console.WriteLine("");
        }
        public static void OfType(int[] nums)
        {
            Console.WriteLine("OfType int");
            nums.OfType<int>().ToList().ForEach(item =>
            {
                Console.Write(item + " ");
            });
            Console.WriteLine("");
        }
    }
    public class Grouping
    {
        public class Student
        {
            public int ID = 1;
            public int DepID = 1;
            public string sName = "Student";
        }
        public class Depart
        {
            public int ID = 1; 
            public string dName = "Depart";
        }

        public Depart[] Departs = new Depart[2];
        public Student[] students = new Student[4];
        public class Customer{
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Order{
            public string Description { get; set; }
            public int CustomerId { get; set; }
        }

        Customer[] customers = new Customer[]
        {
            new Customer { Id = 1, Name = "C1" },
            new Customer { Id = 2, Name = "C2" },
            new Customer { Id = 3, Name = "C3" }
        };
        Order[] orders = new Order[]
        {
            new Order { Description = "O1", CustomerId = 1 },
            new Order { Description = "O2", CustomerId = 1 },
            new Order { Description = "O3", CustomerId = 2 },
            new Order { Description = "O4", CustomerId = 3 },
        };
        public void Init()
        {
            Depart d1 = new Depart();
            Depart d2 = new Depart();
            d1.ID = 1; d1.dName = "Math";
            d2.ID = 2; d2.dName = "Physics";
            Departs[0] = d1;
            Departs[1] = d2; 

            Student s1 = new Student(); 
            Student s2 = new Student(); 
            Student s3 = new Student(); 
            Student s4 = new Student();
            s1.ID = 1; s1.sName = "Moham"; s1.DepID = 1; 
            s2.ID = 2; s2.sName = "HassN"; s2.DepID = 1;
            s3.ID = 3; s3.sName = "Ali  "; s3.DepID = 1;
            s4.ID = 4; s4.sName = "Abass"; s4.DepID = 2;
            students[0] = s1;
            students[1] = s2;
            students[2] = s3;
            students[3] = s4; 
        }
        public void Join()
        {
            Console.WriteLine("Join");
            customers.Join(orders, c => c.Id, o => o.CustomerId, (c, o) => c.Name + "-" +
                o.Description).ToList().ForEach(item =>
                {
                    Console.WriteLine(item);
                });
            Console.WriteLine("");
        }
        public void GroupJoin()
        {
            Console.WriteLine("GroupJoin");
            customers.GroupJoin(orders, c => c.Id, o => o.CustomerId, (c, o) => c.Name).ToList().ForEach(item =>
            {
                Console.WriteLine(item);
            }); ;
            Console.WriteLine("");
        }
        public void ZIP()
        {
            Departs.Zip(students, (d,s) => new { d.dName, s.sName}).ToList().ForEach(item =>
            {
                Console.WriteLine(item.sName + "_" + item.dName);
            }); 
        }
    }
}
