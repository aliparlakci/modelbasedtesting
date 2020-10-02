using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace SpecFlowDemo.API.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        private DbSet<TodoItem> TodoItems { get; set; }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await TodoItems.ToListAsync();
        }

        public async Task<TodoItem> Get(long id)
        {
            return await TodoItems.FindAsync(id);
        }

        public async void Update(long id, TodoItem todoItem)
        {
            Entry(todoItem).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async void Create(TodoItem todoItem)
        {
            Add(todoItem);
            await SaveChangesAsync();
        }

        public async Task<TodoItem> Delete(long id)
        {
            var todoItem = await Get(id);
            if (todoItem == null)
            {
                return null;
            }
            TodoItems.Remove(todoItem);
            await SaveChangesAsync();
            return todoItem;
        }
    }
}
