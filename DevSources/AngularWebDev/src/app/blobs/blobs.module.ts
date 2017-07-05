import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BlobsRoutingModule } from './blobs-routing.module';
import { DefaultComponent } from './default.component';
import { BlobService } from "app/shared/blob.service";

@NgModule({
  imports: [
    CommonModule,
    BlobsRoutingModule
  ],
  declarations: [DefaultComponent],
  providers : [
    BlobService
  ]
})
export class BlobsModule { }
