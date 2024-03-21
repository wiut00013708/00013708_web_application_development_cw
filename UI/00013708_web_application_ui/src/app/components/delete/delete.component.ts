import { Component, inject } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { Numbers } from '../../Numbers';
import { NumbersService } from '../../numbers.service';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {
  deleteNumber: Numbers= {
    id: 0,
    contactId: 0,
    contact:{
        id: 0,
        firstName: "string",
        lastName: "string",
        emailAddress: "string"
    },
    number: "string",
    type: "string"

  }

  serve=inject(NumbersService)
  activateRote= inject(ActivatedRoute)
  router = inject(Router)

  ngOnInit(){
    this.serve.getById(this.activateRote.snapshot.params["id"]).subscribe((result)=>{
      this.deleteNumber = result
    });
  }

  onHomeButtonClick(){
    this.router.navigateByUrl("numbers")
  }

  onDeleteButtonClick(id:number){
    this.serve.delete(id).subscribe(r=>{
      alert("DELETED!")
      this.router.navigateByUrl("numbers")
    });
  }
}
