using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _http;

        public TodoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<Todo>> GetAll()
        {
            using var response = await _http.GetAsync("http://localhost:5000/api/todos");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<List<Todo>>();
        }

        public async Task<Todo> CreateTodo(string todo)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:5000/api/todos"),
                Content = new StringContent(JsonSerializer.Serialize(new { title = todo }), Encoding.UTF8, "application/json"),
            };

            using var response = await _http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<Todo>();
        }

        public async Task<bool> DeleteTodo(int id)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://localhost:5000/api/todos/{id}"),
            };

            using var response = await _http.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}