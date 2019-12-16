using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public List<int> Scores;
    }

    class Teacher
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string City { get; set; }
    }

    class School
    {
        public List<Student> students { get; set; }
        public List<Teacher> teachers { get; set; }
        public School()
        {
            // Create the first data source. 
            students = new List<Student>()
            {
                new Student {First="Svetlana",
                    Last="Omelchenko",
                    ID=111,
                    Street="123 Main Street",
                    City="Seattle",
                    Scores= new List<int> {97, 92, 81, 60}},
                new Student {First="Claire",
                    Last="O’Donnell",
                    ID=112,
                    Street="124 Main Street",
                    City="Redmond",
                    Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven",
                    Last="Mortensen",
                    ID=113,
                    Street="125 Main Street",
                    City="Lake City",
                    Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Jan",
                    Last="Kowalski",
                    ID=114,
                    Street="Koszykowa 2",
                    City="Warsaw",
                    Scores= new List<int> {89, 99, 77, 67}},
                new Student {First="Katarzyna",
                    Last="Kwiatkowska",
                    ID=115,
                    Street="Targowa 3",
                    City="Warsaw",
                    Scores= new List<int> {99, 98, 100, 96}},
                new Student {First="Andrew",
                    Last="Adare",
                    ID=116,
                    Street="32 Livingstone",
                    City="Seattle",
                    Scores= new List<int> {99, 98, 100, 96}}
            };

            // Create the second data source. 
            teachers = new List<Teacher>()
            {
                new Teacher {First="Ann", Last="Beebe", ID=945, City = "Seattle"},
                new Teacher {First="Alex", Last="Robinson", ID=956, City = "Redmond"},
                new Teacher {First="Michiyo", Last="Sato", ID=972, City = "Tacoma"},
                new Teacher {First="Adam", Last="Nowak", ID=973, City = "Warsaw"}
            };
        }
    }
}
