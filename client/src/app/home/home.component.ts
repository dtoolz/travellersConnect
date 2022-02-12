import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  //travellers: any;

  constructor(/*private http: HttpClient*/) { }

  ngOnInit(): void {
    //this.getTravellers();
  }

   registerToggle(){
     this.registerMode = !this.registerMode;
   }

  //  getTravellers () {
  //   this.http.get('https://localhost:5001/api/travellers').subscribe( response => {
  //     this.travellers = response;
  //   })
  //  }

   cancelRegisterMode (event: boolean){
     this.registerMode = event;
   }
}
