import { Injectable } from '@angular/core';
import {Observable, Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NotifierServiceService {
  private subject = new Subject<string>()
  
  constructor() { }
  
  publish(message: string) {
    this.subject.next(message)
  }
  
  listen(): Observable<string> {
    return this.subject.asObservable()
  }
}
