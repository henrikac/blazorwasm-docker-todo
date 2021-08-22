using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Models;

namespace UI.Components
{
    public partial class TodoBox
    {
        private TodoCreate todo = new();
        private List<Todo> todos = new List<Todo>();

        [Inject]
        private HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri("http://localhost:5000/api/todos"),
            };

            // TODO: Error handling
            todos = await JsonSerializer.DeserializeAsync<List<Todo>>(
                await Http.GetStreamAsync(requestMessage.RequestUri),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

        private async Task HandleValidSubmit()
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri("http://localhost:5000/api/todos"),
                Content = new StringContent(JsonSerializer.Serialize(todo), Encoding.UTF8, "application/json"),
            };

            using var response = await Http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error creating new TODO");
                return;
            }

            Todo newTodo = await response.Content.ReadFromJsonAsync<Todo>();
            todos.Add(newTodo);
        }

        private void RemoveTodo(int id)
        {
            Todo todo = todos.FirstOrDefault(t => t.Id == id);

            if (todo is null)
            {
                Console.WriteLine($"Could not find todo with id: {id}");
                return;
            }

            todos.Remove(todo);
        }
    }
}