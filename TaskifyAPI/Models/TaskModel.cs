﻿namespace TaskifyAPI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
