import {NgModule} from "@angular/core";
import {RouterModule, Routes} from "@angular/router";
import {LoginComponent} from "./login/login.component";
import {AdminPanelComponent} from "./admin-panel/admin-panel.component";
import {LoginGuard} from "./login.guard";
import {NotFoundComponent} from "./not-found/not-found.component";

const routes: Routes = [
    {path: "login", component: LoginComponent},
    {path: "admin-panel", component: AdminPanelComponent, canActivate: [LoginGuard]},
    {path: "long/url/to/admin/panel", component: AdminPanelComponent, canActivate: [LoginGuard]},
    {path: "**", component: NotFoundComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
