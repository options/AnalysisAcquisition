import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from "app/home/home.component";

const routes: Routes = [
  { path : 'home', component: HomeComponent },
  { path : '', redirectTo: '/home', pathMatch: 'full' },
  { path : 'bot', loadChildren: 'app/bot/bot.module#BotModule' },
  { path : 'bi', loadChildren: 'app/powerbi/powerbi.module#PowerBIModule' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
