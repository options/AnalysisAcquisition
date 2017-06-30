import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PowerbiRoutingModule } from './powerbi-routing.module';
import { DefaultComponent } from './default.component';

@NgModule({
  imports: [
    CommonModule,
    PowerbiRoutingModule
  ],
  declarations: [DefaultComponent]
})
export class PowerBIModule { }
