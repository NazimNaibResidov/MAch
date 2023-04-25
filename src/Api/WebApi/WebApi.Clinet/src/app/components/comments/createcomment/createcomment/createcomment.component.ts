import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommentService } from 'src/app/services/comments.service';

@Component({
  selector: 'app-createcomment',
  templateUrl: './createcomment.component.html',
  styleUrls: ['./createcomment.component.css']
})
export class CreatecommentComponent implements OnInit {
  commentGroup: FormGroup;
  constructor(private fromBuilder: FormBuilder, private _http: CommentService, private router: Router) { }
  ngOnInit(): void {
    this.Builder();
  }
  Create(): void {
    if (this.commentGroup.valid) {
      let createComment = Object.assign(this.commentGroup.value);
      this._http.createComment(createComment)
        .subscribe((resp) => {
          this.router.navigate(["list_commet"]);
        });

    }

  }
  private Builder() {
    this.commentGroup = this.fromBuilder.group({
      title: new FormControl("", Validators.required || Validators.maxLength(50)),
      content: new FormControl("", Validators.required || Validators.minLength(5))
    })
  }
}
