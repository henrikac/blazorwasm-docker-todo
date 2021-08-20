using Microsoft.AspNetCore.Components;

namespace UI.Components
{
    public partial class TodoItem
    {
        [Parameter]
        public string Title { get; set; }
    }
}