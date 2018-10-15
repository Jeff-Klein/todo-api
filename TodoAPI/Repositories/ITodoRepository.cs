using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        IEnumerable<TodoItem> GetActives();
        TodoItem Get(long id);
        void Create(TodoItem item);
        void Update(long id, TodoItem item);
        void Remove(long id);
        void Delete(long id);
    }
}
