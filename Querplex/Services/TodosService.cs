using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Querplex.Services
{
    public class TodosService : ITodosService
    {
        private List<Todos> _todosItems;

        public TodosService()
        {
            _todosItems = new List<Todos>();
        }

        public List<Todos> GetTodos()
        {
            return _todosItems;
        }


        public Todos AddTodos(Todos todosItem)
        {
            _todosItems.Add(todosItem);
            return todosItem;
        }

        public string DeleteTodos(string id)
        {
            for (var index = _todosItems.Count - 1; index >= 0; index--)
            {
                if (_todosItems[index].ID == id)
                {
                    _todosItems.RemoveAt(index);
                }
            }

            return id;
        }


        public Todos UpdateTodos(string id, Todos todosItem)
        {
            for (var index = _todosItems.Count - 1; index >= 0; index--)
            {
                if (_todosItems[index].ID == id)
                {
                    _todosItems[index] = todosItem;
                }
            }
            return todosItem;
        }
    }
}
