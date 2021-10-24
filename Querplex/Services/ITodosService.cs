using System;
using System.Collections.Generic;

namespace Querplex.Services
{
    public interface ITodosService
    {
        public List<Todos> GetTodos();
        
        public Todos AddTodos(Todos todoItem);
        
        public Todos UpdateTodos(string id, Todos todoItem);
        
        public string DeleteTodos(string id);
        
    }
}
