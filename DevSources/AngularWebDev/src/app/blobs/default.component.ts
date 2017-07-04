import { Component, OnInit } from '@angular/core';
import { IBlob } from "app/shared/model/blob.model";
import { BlobService } from "app/shared/blob.service";

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.css']
})
export class DefaultComponent implements OnInit {
  blobs : IBlob[]
  
  constructor(private blobSvc: BlobService) { }

  ngOnInit() {
    this.loadBlobList();
  }

  loadBlobList() : void {
    this.blobSvc.getBlobs().subscribe( blobs => {
      this.blobs = blobs;
    });
  }

  clickRefresh() : void {
    this.loadBlobList();
  }

}
