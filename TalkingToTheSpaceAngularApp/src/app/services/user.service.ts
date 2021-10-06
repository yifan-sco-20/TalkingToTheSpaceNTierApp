import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { UserResult } from '../models/user-result.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) {}

  //We specify any as the result set as we will map the values to our custom result
  //object
  async AddUser(user: User): Promise<any> {
    return await this.http
      .post<any>(
        'http://localhost:53980/api/User/AddUser', user,{}

      )
      .toPromise();
  }

  async GetUsers(): Promise<UserResult> {
    return await this.http
      .get<UserResult>('http://localhost:53980/api/User/GetAllUsers')
      .toPromise();
  }

  

}
