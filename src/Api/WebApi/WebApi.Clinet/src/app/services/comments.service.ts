import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetComment } from '../models/componentsModul/get-comment';
import { HttpClientService } from './Core/httpclient.service';
import { CreateComment } from '../models/componentsModul/create-comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  isResult:Boolean;
  constructor(private _http: HttpClientService) { }
  createComment(createComment: CreateComment) {
   
   return this._http.post({
      controller: 'Comment',
      action: 'Create'
    }, createComment);
      
     
  }

  GetList(): Observable<GetComment[]> {
    return this._http.get<GetComment[]>({
      controller: 'Comment',
      action:'GetAll'


    });

  }
  Delete(id: string) {
    return this._http.delete<any>({
      controller: 'Comment',
      action: 'Delete',

    }, id);
  }
}
