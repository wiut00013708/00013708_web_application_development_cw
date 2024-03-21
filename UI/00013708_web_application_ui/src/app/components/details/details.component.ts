import { Component, inject } from '@angular/core';
import { Numbers } from '../../Numbers';
import { ActivatedRoute, Router } from '@angular/router';
import { NumbersService } from '../../numbers.service';
import { MatChipsModule } from '@angular/material/chips'
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [ MatChipsModule, MatCardModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
 serviceNumber=inject(NumbersService)
 activatedRoute= inject(ActivatedRoute)
  pNumber: Numbers = {
    id:0,
    contactId:0,
    contact:{
        id:0,
        firstName:"string",
        lastName:"string",
        emailAddress:"string"
    },
    number:"string",
    type:"string"

 }
 
 ngOnInit(){
  this.serviceNumber.getById(this.activatedRoute.snapshot.params["id"]).subscribe(result=>{
    this.pNumber = result
  });
 }


}
