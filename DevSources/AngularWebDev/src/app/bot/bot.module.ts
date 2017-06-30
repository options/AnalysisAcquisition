import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BotRoutingModule } from './bot-routing.module';
import { DefaultComponent } from './default.component';

@NgModule({
  imports: [
    CommonModule,
    BotRoutingModule
  ],
  declarations: [DefaultComponent]
})
export class BotModule { }
