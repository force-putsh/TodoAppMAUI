using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoAppMAUI.Models;

namespace TodoAppMAUI.Services
{
    public class TodoService:ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        
        public TodoService(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient(nameof(TodoService));
            _jsonSerializerOptions = new()
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true
            };
        }

        public async Task AddTodoAsync(Todo todo)
        {
            var response = await _httpClient.PostAsJsonAsync("/todos",todo);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTodoAsync(int todoId)
        {
            var response = await _httpClient.DeleteAsync($"/todos/{todoId}");
            var success=response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            var response = await _httpClient.GetAsync("/todos");
            response.EnsureSuccessStatusCode();
            var todoJson = await response.Content.ReadAsStringAsync();
            var todoList = JsonSerializer.Deserialize<IEnumerable<Todo>>(todoJson,_jsonSerializerOptions);
            return todoList;
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            var response = await _httpClient.PutAsJsonAsync($"/todos/{todo.Id}",todo);
            var isSucces = response.IsSuccessStatusCode;
        }
    }
}
