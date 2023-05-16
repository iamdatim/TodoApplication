using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoItem
{
    internal class Tasks
    {
        public int ListId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string PriorityLevel { get; set; }
        public bool IsComplete { get; set; }
        public Guid UserId { get; set; }
    }
}
