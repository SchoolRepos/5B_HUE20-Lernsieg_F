import {Component, OnInit} from "@angular/core";
import {NotifierServiceService} from "./notifier-service.service";

@Component({
  selector: 'app-root',
  template: `
    LernsiegFrontend
    <hr/>
    <button routerLink="/login">Login</button>
    <button routerLink="/admin-panel">Admin Panel</button>
    <hr/>
    Log:
    <div *ngFor="let message of logMessages">
      {{message}}
    </div>
    <hr/>
    <router-outlet></router-outlet>
  `,
  styles: []
})
export class AppComponent implements OnInit {
  title = 'lernsieg-frontend';
  
  logMessages: string[] = [];

  constructor(private notifier: NotifierServiceService) {
  }
  
  ngOnInit(): void {
    this.notifier.listen().subscribe(msg => this.logMessages.push(msg))
  }
}
