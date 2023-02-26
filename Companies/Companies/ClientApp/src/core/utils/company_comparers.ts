import { Company } from "../models/company.model";


export interface ICompanyComparer {
    childComparer: ICompanyComparer | null;

    compare(a: Company, b: Company): number;
}

export class CompanyNameComparer implements ICompanyComparer {
    childComparer: ICompanyComparer | null;

    constructor(childComparer: ICompanyComparer | null = null) {
        this.childComparer = childComparer;
    }

    compare(a: Company, b: Company): number {
        if (this.childComparer != null && a.companyName === b.companyName) {
            return this.childComparer.compare(a, b);
        }
        return a.companyName.localeCompare(b.companyName);
    }
}

export class CompanyContactNameComparer implements ICompanyComparer {
    childComparer: ICompanyComparer | null;

    constructor(childComparer: ICompanyComparer | null = null) {
        this.childComparer = childComparer;
    }

    compare(a: Company, b: Company): number {
        if (this.childComparer != null && a.contactName === b.contactName) {
            return this.childComparer.compare(a, b);
        }
        return a.contactName.localeCompare(b.contactName);
    }
}

export class CompanyYearsInBusinessComparer implements ICompanyComparer {
    childComparer: ICompanyComparer | null;

    constructor(childComparer: ICompanyComparer | null = null) {
        this.childComparer = childComparer;
    }

    compare(a: Company, b: Company): number {
        if (this.childComparer != null && a.yearsInBusiness === b.yearsInBusiness) {
            return this.childComparer.compare(a, b);
        }
        return a.yearsInBusiness - b.yearsInBusiness;
    }
}