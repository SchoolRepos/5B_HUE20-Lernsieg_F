import { Component, OnInit } from '@angular/core';
import {NotifierServiceService} from "../notifier-service.service";

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {
  constructor(private notifier: NotifierServiceService) { }

  ngOnInit(): void {
  }

  login() {
    localStorage["username"] = "admin";
    this.notifier.publish("Logging in as admin")
  }

  logout() {
    delete localStorage["username"]
  }
}
