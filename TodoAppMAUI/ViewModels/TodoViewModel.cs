using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMAUI.Models;
using TodoAppMAUI.Services;

namespace TodoAppMAUI.ViewModels
{
    public partial class TodoViewModel:ObservableObject
    {
        private readonly ITodoService _todoService;
        private ObservableCollection<Todo> _todos;
        public ReadOnlyObservableCollection<Todo> Todos { get; }

        [ObservableProperty]
        private string _name;

        public TodoViewModel(ITodoService todoService)
        {
            _todoService = todoService;
            _todos = new();
            Todos = new(_todos);

            ThreadPool.QueueUserWorkItem(async _ =>
            {
                await LoaTodoAsync();
            });
        }

        private async Task LoaTodoAsync()
        {
            var todos=await _todoService.GetTodosAsync();
            _todos.Clear();
            foreach (var todo in todos)
            {
                _todos.Add(todo);
            }
        }

        [RelayCommand]
        private async Task CreateTodo()
        {
            var todo=new Todo(Name,false);
            await _todoService.AddTodoAsync(todo);
            await LoaTodoAsync();
            Name=string.Empty;
        }

        [RelayCommand]
        private async Task DeleteTodoAsync(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            await LoaTodoAsync();
        }

        [RelayCommand]
        private async Task UpdateTodoAsync(Todo todo)
        {
            todo.IsCompleted = true;
            await _todoService.UpdateTodoAsync(todo);
            await LoaTodoAsync();
        }
    }
}
