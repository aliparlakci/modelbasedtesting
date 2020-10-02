using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using SpecFlowDemo.API.Models;
using SpecFlowDemo.API.Controllers;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SpecFlowDemo.Test.Drivers
{
    public class TodoItemsControllerDriver
    {
        private TodoItemsController _controller;
        private List<TodoItem> Todos;
        public TodoItemsControllerDriver(TodoItemsController controller)
        {
            _controller = controller;
        }

        public async void AddTodoItem(TodoItem item)
        {
            await _controller.PostTodoItem(item);
        }

        public async void GetAllTodos()
        {
            ActionResult<IEnumerable<TodoItem>> items = await _controller.GetTodoItems();
            Todos = items.Value.ToList();
        }

        public void CountTodos(int count)
        {
            Todos.Count.Should().Be(count);
        }
    }
}
