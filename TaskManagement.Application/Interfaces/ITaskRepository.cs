using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();

        TaskItem? GetById(Guid id);

        void Add(TaskItem task);

        void Update(TaskItem task);

        void Delete(Guid id);
    }
}
