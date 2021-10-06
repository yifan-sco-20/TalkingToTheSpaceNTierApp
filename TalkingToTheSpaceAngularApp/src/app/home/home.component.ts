import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    //kendo ui: drop-down list sample
    public defaultItem = { text: "Filter by Category", value: null };
    public categories: Array<{ text: string; value: number }> = [
      { text: "Beverages", value: 1 },
      { text: "Condiments", value: 2 },
      { text: "Confections", value: 3 },
      { text: "Dairy Products", value: 4 },
      { text: "Grains/Cereals", value: 5 },
      { text: "Meat/Poultry", value: 6 },
      { text: "Produce", value: 7 },
      { text: "Seafood", value: 8 },
    ];



  ngOnInit(): void {
  }



}
