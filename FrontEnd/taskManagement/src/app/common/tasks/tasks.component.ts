import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MaterialModule } from '../../material.module';
import { Tasks } from '../../model/tasks';
import { TasksService } from '../../service/tasks.service';
import { MatTableDataSource } from '@angular/material/table';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-tasks',
    imports: [MaterialModule, RouterLink,DatePipe],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent  implements OnInit{
  displayedColumns: string[] = ["title", "description", "status","dueDate", "action"];
  datasource!: any;

 taskslist:Tasks[]=[]

 constructor(private service:TasksService,private toastr: ToastrService ){
  }

 ngOnInit(): void {
    this.LoadTasks();
  }

   LoadTasks() {
   let sub1= this.service.GetAll().subscribe(item=>{
      this.taskslist=item;
      this.datasource=new MatTableDataSource(this.taskslist);
    })
  }
  Update(id: number, status: string) {
      let _data:Tasks={
        id:id,
        title:"",
        description:"",
        duedate:null,
        status: status  == "Pending" ? "In Progress": "Completed"
      }

      this.service.Update(_data).subscribe(item=>{
        this.toastr.success('Updated Status successfully','Success')
        this.LoadTasks(); 
      }
      ,error=>{
         this.toastr.error('Failed to Update Status',error.error.title);
    })
  }
 
   Delete(id: number) {
      if (confirm('Are you sure?')) {
        this.service.Delete(id).subscribe(item=>{
          this.toastr.success('Deleted successfully','Success')
           this.LoadTasks();
        }
        ,error=>{
         this.toastr.error('Failed to Delete',error.error.title);
      })
      }
  }
}
