import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from "@angular/router";
import {Observable} from "rxjs";

@Injectable({
    providedIn: "root"
})
export class LoginGuard implements CanActivate {
    constructor(private router: Router) {
    }
    
    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

        let allowed = typeof localStorage["username"] === "string";
        if(allowed)
            return true;
        
        this.router.navigate(["/login"], {queryParams: {returnUrl: route.url}});
        return false;
    }

}
