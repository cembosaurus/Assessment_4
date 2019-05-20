import { Component, OnInit } from '@angular/core';
import { ICheck } from '../_models/ICheck';
import { Check } from '../_models/Check';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  check: Check;

  constructor() {

    this.check = new Check();

  }

  ngOnInit() {

    this.check.payee = '';
    // this.check.amount = 123456;
    this.check.amountInWords = '';
    this.check.date = new Date();

    console.warn(this.check);
  }

}
