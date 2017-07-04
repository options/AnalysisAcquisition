import { Injectable } from '@angular/core'
import { Observable} from 'rxjs/Observable'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { IBlob } from "app/shared/model/blob.model";

@Injectable()
export class BlobService {

  constructor(private http: Http) { }

  getBlobs(): Observable<IBlob[]> {
    //console.log("getblob called");
    return this.http.get('http://localhost:3978/api/blob')
      .map((response:Response) => {
        return <IBlob[]>response.json()
      })
      .catch(this.handleError);
  }

  handleError(error:Response){
    return Observable.throw(error.statusText);
  }
}
