import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { NumbersService } from '../../numbers.service';
import { Numbers } from '../../Numbers';

function findIndexByID(jsonArray: any[], indexToFind: number): number {
  return jsonArray.findIndex((item) => item.id === indexToFind);
}

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent {
  serv = inject(NumbersService);
  activatedRoute = inject(ActivatedRoute);
  router = inject(Router);
  editNumber: Numbers = {
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

  };
  contactObject: any; // Category Object for listing
  selected: any // if any selected by default
  conId: number = 0;// category ID To inject to
 
  ngOnInit() {
    console.log(this.activatedRoute.snapshot.params["id"])

    this.serv.getById(this.activatedRoute.snapshot.params["id"]).subscribe(result => {
      this.editNumber = result;
      console.log(this.editNumber)
      this.selected = this.editNumber.contactId;
    });

    this.serv.getAllContacts().subscribe((result) => {
      this.contactObject = result;
    });
  }

  toHome() {
    this.router.navigateByUrl("numbers")
  }

  edit() {
    this.editNumber.contactId = this.conId;
    this.editNumber.contact = this.contactObject[findIndexByID(this.contactObject, this.conId)];
    this.serv.edit(this.editNumber).subscribe(res=>{
      alert("Changes has been updated")
      this.router.navigateByUrl("numbers");
    })
  }
}
