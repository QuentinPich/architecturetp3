using Archi_TP3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archi_TP3.DAL
{
    public class Data
    {

        public static List<User> getUsers()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    login="lena",
                    password="lena"
                },

                 new User()
                {
                    login="sophie",
                    password="sophie"
                },

                  new User()
                {
                    login="sofia",
                    password="sofia"
                },

                   new User()
                {
                    login="quentin",
                    password="quentin"
                }
            };

            return users;
        }

    }
}