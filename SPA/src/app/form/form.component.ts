import { ApiService } from './../_services/api.service';
import { ICheck } from '../_models/ICheck';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Check } from '../_models/Check';
import { markParentViewsForCheckProjectedViews } from '@angular/core/src/view/util';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  check: Check;
  date: Date;
  test: string;


  constructor(private apiService: ApiService, private router: Router) {

    this.check = new Check();

  }

  ngOnInit() {
  }

  submitCheck() {

    console.warn(this.check);

    this.apiService.submitCheck(this.check).subscribe((checkResult: ICheck) => {

      this.check = checkResult;
      this.check.date = new Date(checkResult.date);

    }, err => {

      console.error(err);

    }, () => {

      console.warn(this.check);

      this.router.navigate(['/check' + '/' +
        this.check.payee + '/' +
        this.check.amount + '/' +
        this.check.amountInWords + '/' +
        this.check.date]);

    });


  }

}
