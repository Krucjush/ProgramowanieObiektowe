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
                new User { Name = "a", Role = "ADMIN", Age = 32,
                    Marks = null},
                new User { Name = "b", Role = "MODERATOR", Age = 29,
                    Marks = null},
                new User { Name = "c", Role = "TEACHER", Age = 45,
                    Marks = null},
                new User { Name = "a", Role = "STUDENT", Age = 20,
                    Marks = RandomMarks()},
                new User { Name = "h", Role = "STUDENT", Age = 19,
                    Marks = RandomMarks()},
                new User { Name = "i", Role = "STUDENT", Age = 19,
                    Marks = RandomMarks()},
                new User { Name = "z", Role = "STUDENT", Age = 22,
                    Marks = RandomMarks()},
                new User { Name = "d", Role = "STUDENT", Age = 25,
                    Marks = RandomMarks()}
            };
            Console.WriteLine("Number of records in the list: " + users.Count);
            Console.WriteLine("List of users: ");
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
            var userName = users.Select(u => u.Name).ToList();
            var sortedList = (from user in users orderby user.Name
                              select user.Name).ToList();
            Console.WriteLine("Sorted list of users: ");
            foreach (var user in sortedList)
            {
                Console.WriteLine(user);
            }
            var roles = new List<User>()
            {
                new User { Role = "ADMIN" },
                new User { Role = "MODERATOR" },
                new User { Role = "TEACHER" },
                new User { Role = "STUDENT" }
            };
            Console.WriteLine("Avaliabe user roles: ");
            foreach (var role in roles)
            {
                Console.WriteLine(role.Role);
            }
            var userRoles = roles.Select(r => r.Role).ToList();
            var admins = new List<User>();
            var moderators = new List<User>();
            var teachers = new List<User>();
            var students = new List<User>();
            foreach (var user in users)
            {
                if (user.Role == "ADMIN")
                {
                    admins.Add(user);
                }
                if (user.Role == "MODERATOR")
                {
                    moderators.Add(user);
                }
                if (user.Role == "TEACHER")
                {
                    teachers.Add(user);
                }
                if (user.Role == "STUDENT")
                {
                    students.Add(user);
                }
            }
            Console.WriteLine("Admins: ");
            foreach (var user in admins)
            {
                Console.WriteLine(user.Name);
            }
            Console.WriteLine("Moderators: ");
            foreach (var user in moderators)
            {
                Console.WriteLine(user.Name);
            }
            Console.WriteLine("Teachers: ");
            foreach (var user in teachers)
            {
                Console.WriteLine(user.Name);
            }
            Console.WriteLine("Students: ");
            foreach (var user in students)
            {
                Console.WriteLine(user.Name);
            }
            var nullsNumber = 0;
            foreach (var user in users)
            {
                if (user.Marks == null)
                {
                    nullsNumber++;
                }
            }
            Console.WriteLine("List of no mark users: " + nullsNumber);
        }
        static int[] RandomMarks()
        {
            var random = new Random();
            var randomMarks = new int[5] {random.Next(1, 6), random.Next(1, 6),
            random.Next(1, 6), random.Next(1, 6), random.Next(1, 6) };
            return randomMarks;
        }
    }
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
