import { Component, inject } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { Numbers } from '../../Numbers';
import { MatButtonModule } from '@angular/material/button';
import { NumbersService } from '../../numbers.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-numbers',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './numbers.component.html',
  styleUrl: './numbers.component.css'
})
export class NumbersComponent {

  router = inject(Router)
  numberService = inject(NumbersService)
  itemsList: Numbers[] = [];
  ngOnInit() {
    this.numberService.getAll().subscribe((result) => {
      this.itemsList = result
    });
  }
  displayedColumns: string[] = ['id', 'FirstName','LastName', 'number', 'type', 'Actions'];

  e(id: number) {
     console.log("edit", id); 
    this.router.navigateByUrl("edit/"+id)
    };
  dt(id: number) { 

    this.router.navigateByUrl("details/"+id);
  };
  dl(id: number) { console.log("delete", id); this.router.navigateByUrl("delete/"+id); }
}
