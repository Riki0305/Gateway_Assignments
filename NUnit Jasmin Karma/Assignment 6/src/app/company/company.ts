export class Branch{
  id:number;
  name:string='';
  address:string='';
}

export class Company{
  id:number;
  email:string='';
  name:string='';
  totalEmployee:number=0;
  address:string='';
  isCompanyActive:boolean;
  totalBranch:number=0;
  companyBranch:Branch[];
}
