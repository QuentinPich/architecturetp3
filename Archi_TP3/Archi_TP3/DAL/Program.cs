using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archi_TP3.Models
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new Context())
            {
                Console.Write("test");
                var user = new User() { login="azerty", password="azerty" };
                ctx.Users.Add(user);
                ctx.SaveChanges();

                var query = from u in ctx.Users select u;
                Console.WriteLine("All users in database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.login);
                }
            }
        }
    }
}