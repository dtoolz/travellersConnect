import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = "travellers connect";
  travellers: any;

  constructor(private http:HttpClient){}
  ngOnInit() {
   this.getTravellers();
  }

  getTravellers (){
    this.http.get('https://localhost:5001/api/travellers').subscribe(response => {
      this.travellers = response;
    }, error => {
      console.log(error);
    });
  }
}
