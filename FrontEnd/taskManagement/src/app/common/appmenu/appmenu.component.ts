import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-appmenu',
  imports: [RouterOutlet],
  templateUrl: './appmenu.component.html',
  styleUrl: './appmenu.component.css'
})
export class AppmenuComponent  implements OnInit{
  constructor(private router: Router ) 
   {
  }
  
   ngOnInit(): void {
     this.router.navigateByUrl('/tasks');
   }
}

