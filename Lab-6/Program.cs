using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>()
            {
                new User {Name = "Gabriel", Role = "STUDENT", Age = 24, Marks = new int[] { 3, 3, 3, 3, 3, 3 } },
                new User {Name = "Emma", Role = "STUDENT", Age = 24, Marks = new int[] { 5, 5, 5, 5, 5, 5, 4, 5, 3, 5 }},
                new User {Name = "Ela", Role = "MODERATOR", Age = 34},
                new User {Name = "Tymoteusz", Role = "ADMIN", Age = 29},
                new User {Name = "Roza", Role = "STUDENT", Age = 20, Marks = new int[] { 3, 4, 4, 4, 3, 2, 3 }},
                new User {Name = "Wiktor", Role = "STUDENT", Age = 45, Marks = new int[] { 5, 4, 3, 2, 5, 3, 2, 4 }},
                new User {Name = "Marcin", Role = "TEACHER", Age = 44},
                new User {Name = "Krystyna", Role = "TEACHER", Age = 24},
                new User {Name = "Gertruda", Role = "STUDENT", Age = 44, Marks = new int[] { 4, 5, 4, 5, 4, 5 }},
                new User {Name = "Joachim", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 2, 3, 4, 5, 5, 4, 3 }},
                new User {Name = "Eliza", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 4, 5, 4, 5, 4, 3, 4 }},
                new User {Name = "Marcin", Role = "TEACHER", Age = 44},
                new User {Name = "Klaudia", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 4, 3, 4, 3, 4, 3, 4 }},
                new User {Name = "Teofil", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 2, 3, 4, 3, 2, 3, 4 }},
                new User {Name = "Pamela", Role = "TEACHER", Age = 44},
                new User {Name = "Fabian", Role = "STUDENT", Age = 44, Marks = new int[] { 2, 3, 5, 4, 3, 3, 3 }},
                new User {Name = "Megan", Role = "TEACHER", Age = 44},
                new User {Name = "Roza", Role = "STUDENT", Age = 44, Marks = new int[] { 2, 3, 4, 3, 4, 3, 4 }},
                new User {Name = "Sergiusz", Role = "STUDENT", Age = 44, Marks = new int[] { 5, 5, 5, 5, 5, 4, 5 }},
                new User {Name = "Oliwia", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 4, 5, 4, 5, 4, 5, 3}}
            };
            var recordCount = (from user in users
                               select user).Count();
            Console.WriteLine("Number of records: " + recordCount);
            var userNames = from user in users
                            select user.Name;
            Console.WriteLine("List of user names: ");
            foreach (var name in userNames)
            {
                Console.WriteLine(name);
            }
            var sortedUserNames = (from user in users
                                   orderby user.Name ascending
                                   select user.Name);
            Console.WriteLine("User names sorted ascending:");
            foreach (var name in sortedUserNames)
            {
                Console.WriteLine(name);
            }
            var avaliableRoles = (from user in users
                                  select user.Role).Distinct();
            Console.WriteLine("Avaliable roles: ");
            foreach (var role in avaliableRoles)
            {
                Console.WriteLine(role);
            }
            var usersGrouped = from user in users
                               group user by user.Role into userGroup
                               select userGroup;
            Console.WriteLine("Users grouped by roles:");
            foreach (var grouping in usersGrouped)
            {
                Console.WriteLine(grouping.Key + "S:");//S: so it will look like it's printing plural
                foreach (var group in grouping)
                {
                    Console.WriteLine(group.Name);
                }
            }
            var hasMarkCount = (from user in users
                                where user.Marks != null && user.Marks.Length > 0
                                select user).Count();
            Console.WriteLine("Records that have grades set: ");
            Console.WriteLine(hasMarkCount);
            var marksSum = from user in users
                           where user.Role == "STUDENT"
                           let sum = user.Marks.Sum()
                           select sum;
            Console.WriteLine("Sum of students grades: ");
            foreach (var item in marksSum)
            {
                Console.WriteLine(item);
            }
            var marksCount = from user in users
                             where user.Role == "STUDENT"
                             select user.Marks.Length;
            Console.WriteLine("Number of students grades: ");
            foreach (var item in marksCount)
            {
                Console.WriteLine(item);
            }
            var marksAverage = from user in users
                               where user.Role == "STUDENT"
                               let average = user.Marks.Average()
                               select average;
            Console.WriteLine("Average students grades: ");
            foreach (var v in marksAverage)
            {
                Console.WriteLine(v);
            }
            var bestMark = (from user in users
                            where user.Role == "STUDENT"
                            select user.Marks.Max()).Max();
            Console.WriteLine("Best mark: " + bestMark);
            var worstMark = (from user in users
                             where user.Role == "STUDENT"
                             select user.Marks.Min()).Min();
            Console.WriteLine("Worst mark: " + worstMark);
            var bestStudent = (from user in users
                               where user.Role == "STUDENT"
                               let average = user.Marks.Average()
                               orderby average descending
                               select user).First();
            Console.WriteLine("Best student: " + bestStudent.Name);
            var leastMarks = (from user in users
                             where user.Role == "STUDENT"
                             group user by user.Marks.Length into studentMarks
                             orderby studentMarks.Key
                             select studentMarks).First();
            Console.WriteLine("Students with least marks: ");
            foreach (var item in leastMarks)
            {
                Console.WriteLine(item.Name);
            }
            var mostMarks = (from user in users
                             where user.Role == "STUDENT"
                             group user by user.Marks.Length into studentMarks
                             orderby studentMarks.Key
                             select studentMarks).Last();
            Console.WriteLine("Students with most marks: ");
            foreach (var item in mostMarks)
            {
                Console.WriteLine(item.Name);
            }
            //var mappedObjects = users
            //                    .SelectMany(user => users)
            //                    .Select(user => user.Name)
            //                    .SelectMany(average => marksAverage)
            //                    .Select(average => marksAverage);
            //foreach (var item in mappedObjects)
            //{
                
            //}
        }
    }
}
