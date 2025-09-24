import { Routes } from '@angular/router';
import { AddtaskComponent } from './common/addtask/addtask.component';
import { TasksComponent } from './common/tasks/tasks.component';

export const routes: Routes = [
 {path:'tasks',component:TasksComponent},
 {path:'task/add',component:AddtaskComponent},

];
