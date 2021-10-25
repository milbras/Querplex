import { ChangeDetectorRef, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Todo } from 'src/app/model/todo';
import { TodoService } from 'src/app/service/todo.service';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'dialog-data-example-dialog',
  templateUrl: 'todo-dialog.html',
})
export class DialogDataExampleDialog {
  constructor(public dialogRef: MatDialogRef<DialogDataExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Todo,
  private todoService: TodoService) {}

  SaveCh(name){

    this.todoService.UpdateTodo(name.Id, name).subscribe();
    this.dialogRef.close();
  }
}


@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

  constructor(private todoService: TodoService,
    public dialog: MatDialog,
    private changeDetectorRefs: ChangeDetectorRef) { }

  public todos: Todo[];
  dataSource = new MatTableDataSource<Todo>();
  @ViewChild(MatTable) table: MatTable<Todo>;
  displayedColumns: string[] = ['id', 'name', 'status', 'date', 'action'];
  
  ngOnInit(): void {

    this.todoService.GetTodos().subscribe(data => this.todos = data);
  }

  refresh(){
    
    this.table.renderRows();
  }

  delete(id){

    this.todoService.DeleteTodo(id).subscribe(data => this.table.renderRows());
    this.refresh();
  }

  edit(element){

    this.dialog.open(DialogDataExampleDialog, {
      height: '200px',
      width: '350px',
      data: {
        Id: element.id,
        Name: element.name,
        Status: element.status,
        TodoDate: element.todoDate,
      }
    });
  }

  done(element){

    element.status = true;
    this.todoService.UpdateTodo(element.id, element).subscribe(data => this.table.renderRows());
    this.refresh();
  }


}
