using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace UI.Components
{
    public partial class TodoItem
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<int> OnDeleteCallback { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        private async Task DeleteTodo()
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://localhost:5000/api/todos/{Id}"),
            };

            using var response = await Http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error happened deleting todo");
                return;
            }

            await OnDeleteCallback.InvokeAsync(Id);
        }
    }
}