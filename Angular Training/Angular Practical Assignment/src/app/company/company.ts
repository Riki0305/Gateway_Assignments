import { propArray, required, unique } from "@rxweb/reactive-form-validators";


export class Branch{

  @unique()
  id:number;
  @required()
  name:string='';
  @required()
  address:string='';
}

export class Company{
  @unique()
  id:number;
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

