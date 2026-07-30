using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new();

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }

        public TaskItem? GetById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TaskItem task)
        {
            _tasks.Add(task);
        }

        public void Update(TaskItem task)
        {
            var existingTask = GetById(task.Id);

            if (existingTask == null)
                return;

            existingTask.Title = task.Title;
            existingTask.IsCompleted = task.IsCompleted;
        }

        public void Delete(Guid id)
        {
            var task = GetById(id);

            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
