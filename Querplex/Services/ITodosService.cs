using System;
using System.Collections.Generic;

namespace Querplex.Services
{
    public interface ITodosService
    {
        public List<Todos> GetAllTodos();
        
        public Todos AddTodos(Todos todoItem);
        
        public Todos UpdateTodos(int id, Todos todoItem);
        
        public int DeleteTodos(int id);
        
    }
}
