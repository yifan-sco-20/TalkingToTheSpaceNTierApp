import { Component, OnInit } from '@angular/core';
import { UserResult } from '../models/user-result.model';
import { User } from'../models/user.model'
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-account-register',
  templateUrl: './account-register.component.html',
  styleUrls: ['./account-register.component.css']
})
export class AccountRegisterComponent implements OnInit {

  currentUser: User = new User();
  users: UserResult = new UserResult();
  load: string = 'no-show';
  disabled: string = '';
  constructor(private UserService: UserService) {}

  async ngOnInit(): Promise<void> {
    //GET TH GRADES ON LOAD
    this.users.user_set = [];
    var t = await this.UserService
      .GetUsers()
      .then((data) => {
        if (data.success) {
          this.users = data;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert(error);
      });
  }

  async AddUser() {
    let result = new UserResult();
    this.disabled = 'disabled';
    this.load = '';
    await this.UserService
      .AddUser(this.currentUser)
      .then(
        (data) => {
        result.success = data.success;
        result.userMessage = data.userMessage;
        if (result.success) {
          alert('Register Successfully!');
        } else {
          alert(result.userMessage);
        }
        this.currentUser = new User();
      }
      )
      .catch((error) => {
        alert(
          error.error.userMessage +
            ' Please make sure you have provided all the values'
        );
      });
    this.disabled = '';
    this.load = 'no-show';
  }

}







