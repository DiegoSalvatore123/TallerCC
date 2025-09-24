import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MaterialModule } from '../../material.module';
import { ToastrService } from 'ngx-toastr';
import { Tasks } from '../../model/tasks';
import { TasksService } from '../../service/tasks.service';
import { ActivatedRoute, Router } from '@angular/router';
import { provideNativeDateAdapter } from '@angular/material/core';

@Component({
  selector: 'app-addtask',
   imports: [MaterialModule, ReactiveFormsModule],
  templateUrl: './addtask.component.html',
   providers: [provideNativeDateAdapter()],
  styleUrl: './addtask.component.css'
})
export class AddtaskComponent {
    constructor(
    private builder: FormBuilder, private toastr: ToastrService, private router: Router,
    private service: TasksService, private act: ActivatedRoute) {
  }
  _response:any;
  tasksform = this.builder.group({
    title: this.builder.control('', Validators.required),
    description: this.builder.control('', Validators.required),
    duedate: this.builder.control('', Validators.required),
    status: this.builder.control('Pending', Validators.required),

  })
  SaveTask() {
    if (this.tasksform.valid) {
     var _day =this.tasksform.value.duedate as string
      let _obj: Tasks = {
        
        title: this.tasksform.value.title as string,
        description: this.tasksform.value.description as string,
        duedate: new Date(_day),
        status: 'Pending',
        id:0,
      }
      this.service.Create(_obj).subscribe(item=>{
        this._response=item;
          this.toastr.success('Created successfully','Success')
            this.router.navigateByUrl('/tasks');
        },error=>{
         this.toastr.error('Failed to login',error.error.title);
        });
    }
  }
}
