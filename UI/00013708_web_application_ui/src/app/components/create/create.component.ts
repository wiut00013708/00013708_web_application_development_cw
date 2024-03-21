import { Component, inject } from '@angular/core';
import { NumbersService } from '../../numbers.service';
import { Router } from '@angular/router';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  serviceNumber = inject(NumbersService)
  router = inject(Router)


  contacts: any

  numberToCreate: any = {
    contactId: 0,
    number: "",
    type: ""
  }

  selectedContactId: number = 0

  ngOnInit() {
    this.serviceNumber.getAllContacts().subscribe(result => {
      this.contacts = result
    });
  }

  onCreateBtn() {
    this.numberToCreate.contactId = this.selectedContactId
    this.serviceNumber.createNumber(this.numberToCreate).subscribe(result => {
      alert("Created")
      this.router.navigateByUrl("numbers")
    });
  }
}
