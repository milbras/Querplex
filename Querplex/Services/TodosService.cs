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
            _todosItems = new List<Todos>() {
                new Todos {Id=1, Name= "Solve Querplex task", Status = false, TodoDate = new DateTime(2021, 10, 25) },
                new Todos {Id=2, Name= "Sign Contract with ElevateX for Querplex", Status = false, TodoDate =new DateTime(2021, 10, 29) }};
        }

        public List<Todos> GetAllTodos()
        {
            return _todosItems;
        }


        public Todos AddTodos(Todos todosItem)
        {
            _todosItems.Add(todosItem);
            return todosItem;
        }

        public int DeleteTodos(int id)
        {
            for (var index = _todosItems.Count - 1; index >= 0; index--)
            {
                if (_todosItems[index].Id == id)
                {
                    _todosItems.RemoveAt(index);
                }
            }

            return id;
        }


        public Todos UpdateTodos(int id, Todos todosItem)
        {
            for (var index = _todosItems.Count - 1; index >= 0; index--)
            {
                if (_todosItems[index].Id == id)
                {
                    _todosItems[index] = todosItem;
                }
            }
            return todosItem;
        }

    }
}
