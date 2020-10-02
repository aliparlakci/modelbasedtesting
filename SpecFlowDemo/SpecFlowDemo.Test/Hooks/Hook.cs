using BoDi;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using SpecFlowDemo.API.Models;
using TechTalk.SpecFlow;
using Microsoft.EntityFrameworkCore;
using SpecFlowDemo.API.Controllers;

namespace SpecFlowDemo.Test.Hooks
{
    [Binding]
    public class Hooks
    {
        public Hooks()
        {
        }

        [BeforeScenario(Order = 1)]
        public void RegisterDependencies(IObjectContainer objectContainer)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionsBuilder.UseInMemoryDatabase("TodoList");
            TodoContext context = new TodoContext(optionsBuilder.Options);
            objectContainer.RegisterInstanceAs(new TodoItemsController(context));
        }
    }
}
