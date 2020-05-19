using System;
using System.Collections.Generic;

namespace Todo
{
    public class TodoItemService : TodoService
    {
        private readonly int _todoId;
        public TodoItemService(int todoId)
        {
            _todoId = todoId;
        }
        public override List<Todo> LoadData()
        {
            return Connection.Table<Todo>().Where(x => x.TodoId == _todoId).ToList();
        }
    }
}
