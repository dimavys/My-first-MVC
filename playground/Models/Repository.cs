using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace playground.Models
{
    public class Repository //user
    {
        public List<Task> tasks = new List<Task>();

        [Required(ErrorMessage = "Please enter your nickname")]
        public string nickname { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string password { get; set; }
        public IEnumerable<Task> Tasks
        {
            get
            {
                var sorted = tasks.OrderByDescending(u => u.prior);
                return sorted;
            }
        }
        public void AddTask(Task t)
        {
            tasks.Add(t);
        }

        public void Destroy(string str)
        {
            tasks.RemoveAt(tasks.IndexOf(tasks.Find(x => x.name == str)));
        }

    }
}
