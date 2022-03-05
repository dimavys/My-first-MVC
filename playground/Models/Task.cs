using System;
using System.ComponentModel.DataAnnotations;

namespace playground.Models
{
    public class Task
    {
        [Required(ErrorMessage = "Please enter the task title")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Please enter start date")]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "Please enter finish date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter priority")]
        public int Prior { get; set; }

        public int Id { get; set; }

        public int RepositoryId { get; set; }
    }
}
