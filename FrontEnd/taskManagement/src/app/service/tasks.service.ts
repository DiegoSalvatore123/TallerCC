import { Injectable } from '@angular/core';
import { Tasks } from '../model/tasks';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
baseurl='https://localhost:7299/api/Tasks';
  constructor(private http:HttpClient) { }

 GetAll(){
    return this.http.get<Tasks[]>(this.baseurl);
  }

  Create(_data:Tasks){
    return this.http.post(this.baseurl , _data);
  }

  Update(_data:Tasks){
     return this.http.put(this.baseurl + '/' + _data.id, _data);
  }

  Delete(id:number){
    return this.http.delete(this.baseurl + '/' + id);
  }
}
