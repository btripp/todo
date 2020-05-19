using System;
using System.Collections.Generic;
using SQLite;
namespace Todo
{
    public class TodoService : DatabaseService, ITodoRepoService
    {
        public void Add(Todo item)
        {
            Connection.Insert(item);
        }

        public void Delete(Todo item)
        {
            // always tries to delete parent todos at a low cost for convenience
            Connection.Execute($"delete from {nameof(Todo)} where {nameof(Todo.TodoId)} = ?", item.Id);
            Connection.Delete(item);
        }

        public virtual List<Todo> LoadData()
        {
            // derives unfinished count value to show how many outstanding items are in the list
            string query =
                $" SELECT" +
                $" todos.{nameof(Todo.Id)}," +
                $" todos.{nameof(Todo.Name)}," +
                $" todos.{nameof(Todo.Complete)}," +
                $" (    SELECT count(*) " +
                $"      FROM {nameof(Todo)} subTodo WHERE subTodo.{nameof(Todo.TodoId)} = todos.{nameof(Todo.Id)}" +
                $"      AND subTodo.{nameof(Todo.Complete)} = 0" +
                $" ) {nameof(Todo.UnfinishedCount)}" +
                $" FROM {nameof(Todo)} todos" +
                $" WHERE todos.{nameof(Todo.TodoId)} = 0";

            var todos = Connection.Query<Todo>(query);
            return todos;
        }

        public void Update(Todo item)
        {
            Connection.Update(item);
        }
    }
}
