import { IAccount } from "./Account";

export interface IBookRequest{
    id:number;
    user:IAccount;
    status:number;
}