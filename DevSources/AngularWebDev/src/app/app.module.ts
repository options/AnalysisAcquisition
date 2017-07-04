import './rxjs-extensions'
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from "app/nav/navbar.component";
import { HomeComponent } from './home/home.component';
import { BlobService } from "app/shared/blob.service";


@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule
  ],
  providers: [
    BlobService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
