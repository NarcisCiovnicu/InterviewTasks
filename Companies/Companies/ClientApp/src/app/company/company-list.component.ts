import { Component } from '@angular/core';
import { Company, SortCompaniesCriteriaType } from 'src/core/models/company.model';
import { CompanyService } from 'src/core/services/company.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
})
export class CompanyListComponent {

  public sortCompaniesCriteriaType = SortCompaniesCriteriaType;
  public sortCriteriaSelector: SortCompaniesCriteriaType;
  public companies: Company[] | null = null;

  constructor(private companyService: CompanyService, private snackBar: MatSnackBar) {
    this.sortCriteriaSelector = SortCompaniesCriteriaType.None;
  }

  ngOnInit(): void {
    this.loadCompanies();
  }
  
  sortCompanies() {
    if (this.companies) {
      this.companyService.sort(this.companies, this.sortCriteriaSelector);
    }
  }
  
  exportToCsvFile() {
    this.companyService.exportAsCsvFile(this.companies ?? []);
  }
  
  private loadCompanies() {
    this.companyService.getAll().subscribe({
      next: (response: Company[]) => {
        this.companies = response;
      },
      error: (error) => {
        this.companies = [];
        this.snackBar.open(error, "Close");
      }
    });
  }
}
