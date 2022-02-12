import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Traveller } from '../_models/traveller';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:5001/api/";
  private currentTravellerSource = new ReplaySubject<Traveller>(1);
  currentTraveller$ = this.currentTravellerSource.asObservable();

  constructor(private http:HttpClient) { }

  login(model: any){
     return this.http.post(this.baseUrl + "account/login", model).pipe(
       map((response: Traveller) => {
         const traveller = response;
         if(traveller){
           localStorage.setItem('traveller', JSON.stringify(traveller));
           this.currentTravellerSource.next(traveller);
         }
       })
     );
  }

  setCurrentTraveller(traveller: Traveller){
    this.currentTravellerSource.next(traveller);
  }

  register (model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((traveller: Traveller) => {
         if(traveller) {
           localStorage.setItem('traveller', JSON.stringify(traveller));
           this.currentTravellerSource.next(traveller);
         }
      })
    )
  }

  logout(){
    localStorage.removeItem('traveller');
    this.currentTravellerSource.next(null);
  }
}
