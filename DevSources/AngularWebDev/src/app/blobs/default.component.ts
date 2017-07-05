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
  loaded : boolean = false;

  constructor(private blobSvc: BlobService) { }

  ngOnInit() {
    this.loadBlobList();
  }

  loadBlobList() : void {
    this.loaded = false;
    this.blobSvc.getBlobs().subscribe( blobs => {
      this.blobs = blobs;
      this.loaded = true;
    });
  }

  clickRefresh() : void {
    this.loadBlobList();
  }

}
