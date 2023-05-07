import { Component, OnInit } from '@angular/core';
import {NotifierServiceService} from "../notifier-service.service";
import {ActivatedRoute, ActivatedRouteSnapshot, Router, RouterStateSnapshot} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {
  constructor(private notifier: NotifierServiceService, private params: ActivatedRoute, private router: Router) { }

  private returnUrl: string[] = ["/default-user-page"];
  
  ngOnInit(): void {
    this.params.queryParamMap.subscribe(x => this.returnUrl = x.getAll("returnUrl"));
  }

  login() {
    localStorage["username"] = "admin";
    this.notifier.publish("Logging in as admin")
    this.router.navigate(this.returnUrl)
  }

  logout() {
    delete localStorage["username"]
    this.notifier.publish("Logout")
  }
}
