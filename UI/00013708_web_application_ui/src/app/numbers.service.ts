import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Numbers } from './Numbers';

@Injectable({
  providedIn: 'root'
})
export class NumbersService {
  httpClient = inject(HttpClient)
  constructor() { }

  getAll(){
    return this.httpClient.get<Numbers[]>("https://localhost:7146/api/Numbers/GetAll")
  };
  getAllContacts(){
    return this.httpClient.get("https://localhost:7146/api/Contacts/GetAll")
  }

  createNumber(number:any){
    return this.httpClient.post("https://localhost:7146/api/Numbers/Create/", number);
  }

  getById(id:number){
    return this.httpClient.get<Numbers>("https://localhost:7146/api/Numbers/GetByID/"+id)
  }

  edit(number:Numbers){
    return this.httpClient.put("https://localhost:7146/api/Numbers/Update", number);  
  };
  
  delete(id:number){
    return this.httpClient.delete("https://localhost:7146/api/Numbers/Delete/"+id);
  };

}
