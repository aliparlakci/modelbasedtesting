using TechTalk.SpecFlow;
using FluentAssertions;
using System;
using SpecFlowDemo.Test.Drivers;
using System.Collections.Generic;
using SpecFlowDemo.API.Models;

namespace SpecFlowDemo.Test.Steps
{
    [Binding]
    public sealed class TodoStepDefinitions
    {
        private TodoItemsControllerDriver _driver;
        public TodoStepDefinitions(TodoItemsControllerDriver driver)
        {
            _driver = driver;
        }

        [Given(@"the following todos:")]
        public void GivenTheFollowingTodos(Table table)
        {
            foreach (var row in table.Rows)
            {
                TodoItem item = new TodoItem();
                item.Name = row[0];
                item.IsComplete = row[1] == "Yes";
                _driver.AddTodoItem(item);
            }
        }

        [When(@"I make a get request to /api/TodoList")]
        public async void WhenIMakeAGetRequestToApiTodoList()
        {
            _driver.GetAllTodos();
        }

        [Then(@"It should return a list with (.*) todos")]
        public void ThenItShouldReturnAListWithTodos(int count)
        {
            _driver.CountTodos(count);
        }
    }
}
