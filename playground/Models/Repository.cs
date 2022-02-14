using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace playground.Models
{
    public class Repository //user
    {
        private static int counter = 1;

        private List<Task> tasks = new List<Task>();

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
            t.id = counter;
            counter++;
        }

        public void Destroy(int id)
        {
            tasks.RemoveAt(tasks.IndexOf(tasks.Find(x => x.id == id)));
        }

        public Task Finder (int id)
        {
            return tasks.Find(x => x.id == id);
        }

        public void FillUp(Task t1, Task t2)
        {
            t2.name = t1.name;
            t2.desc = t1.desc;
            t2.deadline = t1.deadline;
            t2.start_date = t1.start_date;
            t2.prior = t1.prior;
        }

    }
}
