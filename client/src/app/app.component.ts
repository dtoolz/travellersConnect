/* import { HttpClient } from '@angular/common/http'; */
import { Component, OnInit } from '@angular/core';
import { Traveller } from './_models/traveller';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  //title = "travellers connect";
  travellers: any;

  constructor(/* private http:HttpClient, */ private accountService: AccountService){}

  ngOnInit() {
  // this.getTravellers();
   this.setCurrentTraveller();
  }

  setCurrentTraveller(){
    const traveller: Traveller = JSON.parse(localStorage.getItem('traveller'));
    this.accountService.setCurrentTraveller(traveller);
  }

 /*  getTravellers (){
    this.http.get('https://localhost:5001/api/travellers').subscribe(response => {
      this.travellers = response;
    }, error => {
      console.log(error);
    });
  } */
}
