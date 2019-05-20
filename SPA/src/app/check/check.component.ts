import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Check } from '../_models/Check';

@Component({
  selector: 'app-check',
  templateUrl: './check.component.html',
  styleUrls: ['./check.component.css']
})
export class CheckComponent implements OnInit {

  check = new Check();
  dateString: string;

  constructor(private route: ActivatedRoute) {

    // console.log(this.route.snapshot.params['payee']);

    this.route.params.subscribe(params => {
      this.check.payee = params['payee'],
      this.check.amount = params['amount'],
      this.check.amountInWords = params['amountInWords'],
      this.check.date = new Date(params['date']);
    });

     // tslint:disable-next-line:max-line-length
    this.dateString = this.check.date.getDate().toString() + '/' +  this.check.date.getMonth().toString() + '/' + this.check.date.getFullYear().toString();

    console.log(this.check);

  }

  ngOnInit() {
  }

}
