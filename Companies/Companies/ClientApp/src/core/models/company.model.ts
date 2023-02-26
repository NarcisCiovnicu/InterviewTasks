
export class Company {
    companyName: string;
    yearsInBusiness: number;
    contactName: string;
    contactPhoneNumber: string;
    contactEmail: string | null;
}

export enum SortCompaniesCriteriaType {
    None = 0,
    CompanyName = 1,
    ContactName = 2,
    YearsInBusinessThenName = 3,
    ContactNameThenYearsInBusinessThenName = 4
  }
