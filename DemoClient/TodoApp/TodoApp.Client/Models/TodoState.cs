using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Client.Models
{
    public class TodoState
    {
        private readonly Stack<IEnumerable<TodoItem>> _todoBuffer = new Stack<IEnumerable<TodoItem>>();

        public IEnumerable<TodoItem> Current => _todoBuffer.Count == 0 ? new List<TodoItem>() : _todoBuffer.Peek();

        public int Count() => Current.Count(todo => !todo.IsDone);

        public bool CanUndo() => _todoBuffer.Count > 0;

        public void AddTodo(TodoItem item)
        {
            var newState = new List<TodoItem>(Current) { item };
            _todoBuffer.Push(newState);
        }

        public void ClearFinished()
        {
            if (Current.Any(todo => todo.IsDone))
                _todoBuffer.Push(Current.Where(todo => !todo.IsDone).ToList());
        }

        public void Undo()
        {
            if (_todoBuffer.Count > 0)
                _todoBuffer.Pop();
        }
    }
}
