import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Todo } from '../model/todo';

@Injectable({
  providedIn: 'root'
})

export class TodoService {

  constructor(private http: HttpClient) { }

  private url = 'https://localhost:44319/api/todos';

  public GetTodos(){
  
    return this.http.get<Todo[]>(this.url);
  }

  public UpdateTodo(id: number, todo: Todo){

    return this.http.put(this.url + '/' + id, todo);
  }

  public DeleteTodo(id: number){

    return this.http.delete(this.url + '/' + id);
  }

}
