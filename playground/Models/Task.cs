using System;
using System.ComponentModel.DataAnnotations;

namespace playground.Models
{
    public class Task
    {
        [Required(ErrorMessage = "Please enter the task title")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string desc { get; set; }

        [Required(ErrorMessage = "Please enter start date")]
        public DateTime deadline { get; set; }

        [Required(ErrorMessage = "Please enter finish date")]
        public DateTime start_date { get; set; }

        [Required(ErrorMessage = "Please enter priority")]
        public int prior { get; set; }
    }
}
