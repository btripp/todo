using System;
using System.Collections.Generic;
namespace Todo
{
    public interface ITodoRepoService
    {
        void Add(Todo item);
        void Update(Todo item);
        void Delete(Todo item);
        List<Todo> LoadData();
    }
}
