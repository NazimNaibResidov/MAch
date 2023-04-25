import { Component } from '@angular/core';
import { GetComment } from 'src/app/models/componentsModul/get-comment';
import { CommentService } from 'src/app/services/comments.service';

@Component({
  selector: 'app-listcomment',
  templateUrl: './listcomment.component.html',
  styleUrls: ['./listcomment.component.css']
})
export class ListcommentComponent {
  items?:GetComment[];
  constructor(private _http:CommentService){}
  ngOnInit(): void {
    this.GET();
  }
  GET(){
   this._http.GetList()
   .subscribe((resp:GetComment[])=>{
    this.items=resp;
   });
   
    
  }
  Delete(item){
    this._http.Delete(item.id)
    .subscribe((res)=>{
      console.log(res);
     const index:number=this.items.indexOf(item);
     if(index!=-1){
      this.items.splice(index,1);
     }
    });
  }
}

