import {NgModule} from "@angular/core";
import {RouterModule, Routes} from "@angular/router";
import {LoginComponent} from "./login/login.component";
import {AdminPanelComponent} from "./admin-panel/admin-panel.component";

const routes: Routes = [
    {path: "login", component: LoginComponent},
    {path: "admin-panel", component: AdminPanelComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
