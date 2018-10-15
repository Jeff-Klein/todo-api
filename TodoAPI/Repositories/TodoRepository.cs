using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context) : base(context)
        {
            _context = context;
        }        

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        public IEnumerable<TodoItem> GetActives()
        {
            return _context.TodoItems.Where(x => x.Removed.Year == 0001).ToList();
        }
        public TodoItem Get(long id)
        {
            return _context.TodoItems.Find(id);
        }

        public void Create(TodoItem item)
        {
            item.Created = DateTime.Now;
            _context.TodoItems.Add(item);
            _context.SaveChanges();
        }

        public void Update(long id, TodoItem item)
        {
            var todo = _context.TodoItems.Find(id);

            todo.Title = item.Title;
            todo.Created = item.Created;
            todo.Edited = DateTime.Now;
            todo.Description = item.Description;
            todo.Removed = item.Removed;

            if (item.IsComplete && !todo.IsComplete)
                todo.Completed = DateTime.Now;
            else if (!item.IsComplete && todo.IsComplete)
                todo.Completed = new DateTime();
            else
                todo.Completed = item.Completed;

            todo.IsComplete = item.IsComplete;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
        }

        public void Remove(long id)
        {
            var todo = _context.TodoItems.Find(id);
            todo.Removed = DateTime.Now;
            _context.TodoItems.Update(todo);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
        }
    }
}
