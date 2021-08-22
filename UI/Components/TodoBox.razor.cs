using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Models;
using UI.Services;

namespace UI.Components
{
    public partial class TodoBox
    {
        private TodoCreate todo = new();
        private ICollection<Todo> todos = new List<Todo>();

        [Inject]
        private ITodoService todoService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            todos = await todoService.GetAll();

            if (todos is null)
            {
                Console.WriteLine("Error happened fetching todos");
                todos = new List<Todo>();
            }
        }

        private async Task HandleValidSubmit()
        {
            Todo newTodo = await todoService.CreateTodo(todo.Title);

            if (newTodo is null)
            {
                Console.WriteLine("Error creating new TODO");
                return;
            }

            todos.Add(newTodo);
        }

        private async Task RemoveTodo(int id)
        {
            Todo todo = todos.FirstOrDefault(t => t.Id == id);

            if (todo is null)
            {
                Console.WriteLine($"Could not find todo with id: {id}");
                return;
            }

            bool removed = await todoService.DeleteTodo(id);

            if (!removed)
            {
                Console.WriteLine("Error happened deleting todo");
                return;
            }

            todos.Remove(todo);
        }
    }
}