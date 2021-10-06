import { HttpClient } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';
import { User } from 'user';
import { UserResult } from 'usersResult';

let httpClient = new HttpClient();
export class App {
  public message = 'Hello World!';

  constructor() {}

  getData() {
  httpClient.fetch('http://localhost:53980/api/User/GetAllUsers')
  .then(response => response.json())
  .then(data => {
    console.log(data);
  });
  }

  
  


}
