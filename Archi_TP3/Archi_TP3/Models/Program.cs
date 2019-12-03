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

                var user = new User() { login="azerty", password="azerty" };
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }
    }
}