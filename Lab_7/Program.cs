using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Lab_7
{

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=PK1-15;Initial Catalog=projectdb;Integrated Security=True";
            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();
                IQueryable<UserEntity> query = users
                                               .Where(q => q.RemovedAt.HasValue == false);
                foreach (var user in query)
                {
                    Console.WriteLine("{0} {1}",user.Id, user.Name);
                }
            }
        }
    }
}
