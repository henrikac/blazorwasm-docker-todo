using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UI.Services;

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

        private async Task DeleteTodo()
        {
            await OnDeleteCallback.InvokeAsync(Id);
        }
    }
}