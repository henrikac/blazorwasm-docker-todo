using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Services
{
    public interface ITodoService
    {
        Task<ICollection<Todo>> GetAll();
        Task<Todo> CreateTodo(string todo);
        Task<bool> DeleteTodo(int id);
    }
}