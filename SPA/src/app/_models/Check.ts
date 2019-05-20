import { ICheck } from './ICheck';

export class Check implements ICheck {

    payee: string;
    amount: number;
    amountInWords: string;
    date: Date;

}
