import { propArray, required } from "@rxweb/reactive-form-validators";
import { unique } from "jquery";

export class Branch{

  @required()
  id:number=0;
  @required()
  name:string='';
  @required()
  address:string='';
}

export class Company{
  @required()
  id:number=0;
  @required()
  email:string='';
  @required()
  name:string='';
  @required()
  totalEmployee:number=0;
  @required()
  address:string='';
  @required()
  isCompanyActive:boolean;
  totalBranch:number=0;

  @propArray(Branch)
  companyBranch:Branch[];
}

