using System;
using System.Collections.Generic;

namespace playground.Models
{
    public static class ListUsers
    {
        
        public static List<Repository> users = new List<Repository>();
        public static void AddUser(Repository r)
        {
            users.Add(r);
        }

        public static Repository UserFinder(string name)
        {
            var tmp = users.Find(x => x.nickname == name);
            return tmp;
        }

    }
}
