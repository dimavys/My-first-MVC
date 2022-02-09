using System;
using System.Collections.Generic;

namespace playground.Models
{
    public static class ListUsers
    {
        public static List<Repository> users = new List<Repository>();
        public static IEnumerable<Repository> Users
        {
            get
            {
                return users;
            }
        }
        public static void AddUser(Repository r)
        {
            users.Add(r);
        }

    }
}
