using System;
namespace TodoAPI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public DateTime Completed { get; set; }
        public DateTime Removed { get; set; }
    }
}
