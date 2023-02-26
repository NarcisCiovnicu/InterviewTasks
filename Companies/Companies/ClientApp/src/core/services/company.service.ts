import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { catchError, map, Observable } from "rxjs";
import { Company, SortCompaniesCriteriaType } from "../models/company.model";
import { saveAs } from 'file-saver';
import { transformError } from "../utils/error_helpers";
import { CompanyContactNameComparer, CompanyNameComparer, CompanyYearsInBusinessComparer } from "../utils/company_comparers";

@Injectable({
    providedIn: 'root'
})
export class CompanyService {
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) 
  {}
  
  getAll(): Observable<Company[]> {
      return this.httpClient.get<Company[]>(`${this.baseUrl}api/Company/GetAll`)
      .pipe(
          map(response => { return response; }),
          catchError(transformError)
      );
  }

  sort(companies: Company[], sortCriteria: SortCompaniesCriteriaType) {
    switch (sortCriteria) {
      case SortCompaniesCriteriaType.CompanyName:
        {
          let nameComparer = new CompanyNameComparer();
          companies.sort((a, b) => nameComparer.compare(a, b));
          break;
        }
      case SortCompaniesCriteriaType.ContactName:
        {
          let contactNameComparer = new CompanyContactNameComparer();
          companies.sort((a, b) => contactNameComparer.compare(a, b));
          break;
        }
      case SortCompaniesCriteriaType.YearsInBusinessThenName:
        {
          let nameComparer = new CompanyNameComparer();
          let yearsInBusinessComparer = new CompanyYearsInBusinessComparer(nameComparer);
          companies.sort((a, b) => yearsInBusinessComparer.compare(a, b));
          break;
        }
      case SortCompaniesCriteriaType.ContactNameThenYearsInBusinessThenName:
        {
          let nameComparer = new CompanyNameComparer();
          let yearsInBusinessComparer = new CompanyYearsInBusinessComparer(nameComparer);
          let contactNameComparer = new CompanyContactNameComparer(yearsInBusinessComparer);
          companies.sort((a, b) => contactNameComparer.compare(a, b));
          break;
        }
    }
  }

  exportAsCsvFile(companies: Company[]): void {
    let csvFile = this.transformToCsvFile(companies);
    saveAs(csvFile, "Companies.csv");
  }

  private transformToCsvFile(companies : Company[]): Blob {
    let csvContent = "Company Name,Years in business,Contact Name,Contact Phone Number,Contact Email \r\n";
    companies.forEach((company: Company) => {
      csvContent += `"${company.companyName}","${company.yearsInBusiness ?? ''}","${company.contactName ?? ''}","${company.contactPhoneNumber}","${company.contactEmail ?? ''}"\r\n`;
    });
    return new Blob([csvContent], {type: 'text/csv' });
  }
}

