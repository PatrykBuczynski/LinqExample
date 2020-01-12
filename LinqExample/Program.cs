using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            School schoolCollection = new School();


            //****** Task [0] ******
            Console.WriteLine("\n Task [0] \n");
            int[] randomNumbers = new int[10];
            Random randomGenerator = new Random();
            for(int i = 0; i<10; i++)
            {
                randomNumbers[i] = randomGenerator.Next(100);
            }

            foreach (int i in randomNumbers) 
            {
                Console.WriteLine("{0}", i);
            }

            var task0Query =
                (from num in randomNumbers select num).Count();

            var task0EvenQuery = 
                (from num in randomNumbers
                where (num % 2) == 0
                select num).Count();
            var task0OddQuery = 
                (from num in randomNumbers
                where (num % 2) != 0
                select num).ToArray();

            Console.WriteLine("Number of elements: {0}", task0Query);
            Console.WriteLine("Number of even elements in Array: {0}", task0EvenQuery);
            Console.WriteLine("All Odd elements of Array: ");
            foreach (int i in task0OddQuery) 
            {
                Console.WriteLine("{0}", i);
            }
            Console.WriteLine("\n");
            int[,] random2DArray = new int[10,5];

            for (int i = 0; i < 10; i++) 
            {
                for (int j = 0; j < 5; j++) 
                {
                    random2DArray[i,j] = randomGenerator.Next(100);
                    Console.WriteLine("{0}", random2DArray[i,j]);
                }
            }
            //****** Task [1] ******
            Console.WriteLine("\n Task [1] \n");
            var task1Query =
                 from student in schoolCollection.students
                 where student.City == "Seattle" || student.City == "Warsaw"
                 select student;

            foreach (Student student in task1Query) 
            {
                Console.WriteLine(student.First + " " + student.Last);
            }
            int task1Number = task1Query.Count();
            Console.WriteLine("Number of students: " + task1Number);

            //****** Task [2] ******
            Console.WriteLine("\n Task [2] \n");
            var task2Query =
                from student in schoolCollection.students
                where student.City == "Seattle" || student.City == "Warsaw"
                orderby student.Last  ascending
                select student;
            foreach (Student student in task2Query)
            {
                Console.WriteLine(student.First + " " + student.Last);
            }
            //****** Task [3] ******
            Console.WriteLine("\n Task [3] \n");
            var task3Query =
                from student in schoolCollection.students
                group student by student.City;

            foreach (var studentsGroup in task3Query) 
            {
                Console.WriteLine(studentsGroup.Key);
                foreach (Student student in studentsGroup) 
                {
                    Console.WriteLine("Name: {0} Surname: {1}", student.First, student.Last);
                }
            }
            //****** Task [4] ******
            Console.WriteLine("\n Task [4] \n");

            var task4Query =
                (from student in schoolCollection.students
                where student.City == "Warsaw"
                select student.Last).Concat(from teacher in schoolCollection.teachers
                                            where teacher.City == "Warsaw"
                                            select teacher.Last);
            foreach (string name in task4Query) 
            {
                Console.WriteLine(name);
            }
            //****** Task [5] ******
            Console.WriteLine("\n Task [5] \n");

            var task5Query =
            (from student in schoolCollection.students
             where student.City == "Warsaw"
             select new {Name = student.First, Surname = student.Last }).Concat(from teacher in schoolCollection.teachers
                                         where teacher.City == "Warsaw"
                                         select new { Name = teacher.First, Surname = teacher.Last });
            foreach (var subset in task5Query)
            {
                Console.WriteLine("Name:" + subset.Name + " Surname: " + subset.Surname);
            }
            //****** Task [6] ******
            Console.WriteLine("\n Task [6] \n");

            Console.WriteLine("\n Task [1] recreated \n");

            var task6aQuery = schoolCollection.students.Where(student => student.City == "Seattle" || student.City == "Warsaw");

            foreach (Student student in task6aQuery)
            {
                Console.WriteLine(student.First + " " + student.Last);
            }
            int task6Number = task6aQuery.Count();
            Console.WriteLine("Number of students: " + task6Number);


            Console.WriteLine("\n Task [4] recreated \n");


            var task6bQuery = schoolCollection.students.Where(student => student.City == "Warsaw").Select(student => student.Last).Concat(schoolCollection.teachers.Where(teacher => teacher.City == "Warsaw").Select(teacher => teacher.Last));


            foreach (string name in task6bQuery)
            {
                Console.WriteLine(name);
            }


            //****** Task [7] ******
            Console.WriteLine("\n Task [7] \n");

            var task7Query = new XElement("Root",
                from student in schoolCollection.students
                let x = string.Format("{0}, {1}, {2}, {3}", student.Scores[0], student.Scores[1], student.Scores[2], student.Scores[3])
                select new XElement("student",
                 new XElement("First", student.First),
                 new XElement("Last", student.Last),
                 new XElement("Scores", x)
                 )
                );
            Console.WriteLine(task7Query);
            Console.ReadKey();
        }
    }
}
