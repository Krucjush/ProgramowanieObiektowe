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
                new User {Name = "Gabriel", Role = "STUDENT", Age = 24, Marks = new int[] { 3, 3, 3, 3, 3, 3 }, CreatedAt = new DateTime(2021, 3, 1), RemovedAt = new DateTime(2021, 3, 15)},
                new User {Name = "Emma", Role = "STUDENT", Age = 24, Marks = new int[] { 5, 5, 5, 5, 5, 5, 4, 5, 3, 5 }, CreatedAt = new DateTime(2022, 1, 5)},
                new User {Name = "Ela", Role = "MODERATOR", Age = 34, CreatedAt = new DateTime(2015, 7, 24)},
                new User {Name = "Tymoteusz", Role = "ADMIN", Age = 29, CreatedAt = new DateTime(2022, 5, 5)},
                new User {Name = "Roza", Role = "STUDENT", Age = 20, Marks = new int[] { 3, 4, 4, 4, 3, 2, 3 }, CreatedAt = new DateTime(2020, 12, 3)},
                new User {Name = "Wiktor", Role = "STUDENT", Age = 45, Marks = new int[] { 5, 4, 3, 2, 5, 3, 2, 4 }, CreatedAt = new DateTime(2019, 1, 3)},
                new User {Name = "Marcin", Role = "TEACHER", Age = 44, CreatedAt = new DateTime(2008, 3, 7)},
                new User {Name = "Krystyna", Role = "TEACHER", Age = 24, CreatedAt = new DateTime(2015, 7, 22)},
                new User {Name = "Gertruda", Role = "STUDENT", Age = 44, Marks = new int[] { 4, 5, 4, 5, 4, 5 }, CreatedAt = new DateTime(2020, 2, 3), RemovedAt = new DateTime(2022, 5, 5)},
                new User {Name = "Joachim", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 2, 3, 4, 5, 5, 4, 3 }, CreatedAt = new DateTime(2020, 1, 9)},
                new User {Name = "Eliza", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 4, 5, 4, 5, 4, 3, 4 }, CreatedAt = new DateTime(2022, 1, 19)},
                new User {Name = "Marcin", Role = "TEACHER", Age = 44, CreatedAt = new DateTime(2021, 12, 18)},
                new User {Name = "Klaudia", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 4, 3, 4, 3, 4, 3, 4 }, CreatedAt = new DateTime(2020, 9, 17)},
                new User {Name = "Teofil", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 2, 3, 4, 3, 2, 3, 4 }, CreatedAt = new DateTime(2020, 12, 19)},
                new User {Name = "Pamela", Role = "TEACHER", Age = 44, CreatedAt = new DateTime(2018, 8, 30)},
                new User {Name = "Fabian", Role = "STUDENT", Age = 44, Marks = new int[] { 2, 3, 5, 4, 3, 3, 3 }, CreatedAt = new DateTime(2020, 8, 19)},
                new User {Name = "Megan", Role = "TEACHER", Age = 44, CreatedAt = new DateTime(2010, 10, 15), RemovedAt = new DateTime (2020, 12, 7)},
                new User {Name = "Roza", Role = "STUDENT", Age = 44, Marks = new int[] { 2, 3, 4, 3, 4, 3, 4 }, CreatedAt = new DateTime(2020, 12, 5)},
                new User {Name = "Sergiusz", Role = "STUDENT", Age = 44, Marks = new int[] { 5, 5, 5, 5, 5, 4, 5 }, CreatedAt = new DateTime(2018, 12, 12)},
                new User {Name = "Oliwia", Role = "STUDENT", Age = 44, Marks = new int[] { 3, 4, 5, 4, 5, 4, 5, 3}, CreatedAt = new DateTime(2022, 1, 1)}
            };
            var recordCount = users
                              .Select(q => users).Count();
            Console.WriteLine("Number of records: " + recordCount);
            var userNames = users
                            .Select(q => q.Name);
            Console.WriteLine("List of user names: ");
            foreach (var item in userNames)
            {
                Console.WriteLine(item);
            }
            var sortedUserNames = users
                                  .OrderBy(q => q.Name);
            Console.WriteLine("User names sorted ascending:");
            foreach (var item in sortedUserNames)
            {
                Console.WriteLine(item.Name);
            }
            var avaliableRoles = users
                                 .Select(q => q.Role).Distinct();
            Console.WriteLine("Avaliable roles: ");
            foreach (var item in avaliableRoles)
            {
                Console.WriteLine(item);
            }
            var usersGrouped = users
                               .OrderBy(q => q.Role);
            Console.WriteLine("Users grouped by roles:");
            foreach (var item in usersGrouped)
            {
                Console.WriteLine(item.Role + ' ' + item.Name);
            }
            var hasMarkCount = users
                               .Where(q => q.Marks != null && q.Marks.Length > 0);
            Console.WriteLine("Records that have grades set: " + hasMarkCount.Count());
            var marksSum = hasMarkCount
                                  .Select(q => q.Marks.Sum());
            Console.WriteLine("Sum of students grades: ");
            foreach (var item in marksSum)
            {
                Console.WriteLine(item);
            }
            var marksCount = hasMarkCount
                             .Select(q => q.Marks.Count());
            Console.WriteLine("Number of students grades: ");
            foreach (var item in marksCount)
            {
                Console.WriteLine(item);
            }
            var marksAverage = hasMarkCount
                               .Select(q => q.Marks.Average());
            Console.WriteLine("Average of students grades: ");
            foreach (var v in marksAverage)
            {
                Console.WriteLine(v);
            }
            var bestMark = hasMarkCount
                           .Select(q => q.Marks.Max())
                           .Max();
            Console.WriteLine("Best mark: " + bestMark);
            var worstMark = hasMarkCount
                            .Select(q => q.Marks.Min())
                            .Min();
            Console.WriteLine("Worst mark: " + worstMark);
            var bestStudent = users
                              .Where(q => q.Role == "STUDENT")
                              .OrderBy(q => q.Marks.Average())
                              .Select(q => q.Name).Last();
            Console.WriteLine("Best student: " + bestStudent);
            var leastMarks = users
                             .Where(q => q.Role == "STUDENT")
                             .GroupBy(q => q.Marks.Length)
                             .OrderBy(q => q.Key).First();
            Console.WriteLine("Students with least marks: ");
            foreach (var item in leastMarks)
            {
                Console.WriteLine(item.Name);
            }
            var mostMarks = users
                            .Where(q => q.Role == "STUDENT")
                            .GroupBy(q => q.Marks.Length)
                            .OrderBy(q => q.Key).Last();
            Console.WriteLine("Students with most marks: ");
            foreach (var item in mostMarks)
            {
                Console.WriteLine(item.Name);
            }
            var mappedObjects = users
                                .Where(q => q.Name != null && q.Marks != null)
                                .Select(q => q.Name);
            Console.WriteLine("Users that have name and average mark: ");
            foreach (var item in mappedObjects)
            {
                Console.WriteLine(item);
            }
            var studentsSortedByTheBest = users
                                          .Where(q => q.Role == "STUDENT")
                                          .OrderByDescending(q => q.Marks.Average())
                                          .Select(q => q.Name);
            Console.WriteLine("Students by average of marks: ");
            foreach (var item in studentsSortedByTheBest)
            {
                Console.WriteLine(item);
            }
            var averageOfAllStudentsTogether = users
                                               .Where(q => q.Role == "STUDENT")
                                               .Select(q => q.Marks.Average()).Average();
            Console.WriteLine("Average of all students grades: " + averageOfAllStudentsTogether);
            var usersGroupedByDateAdded = users
                                          .OrderBy(q => q.CreatedAt);
            Console.WriteLine("Users sorted by time added: ");
            foreach (var item in usersGroupedByDateAdded)
            {
                Console.WriteLine(item.Name + ' ' + item.CreatedAt);
            }
            var notRemovedUsers = users
                                  .Where(q => q.RemovedAt == null);
            Console.WriteLine("Users that are not removed: ");
            foreach (var item in notRemovedUsers)
            {
                Console.WriteLine(item.Name);
            }
            var newestStudent = users
                                .Where(q => q.Role == "STUDENT")
                                .OrderBy(q => q.CreatedAt).Last();
            Console.WriteLine("Newest student: " + newestStudent.Name);
        }
    }
}
