import { HttpErrorResponse } from "@angular/common/http";
import { throwError } from "rxjs";

export function transformError(error: HttpErrorResponse | string) {
    let errorMessage = 'Something bad happened; please try again later.';
  
    if (typeof error === 'string') {
      errorMessage = error;
    } else if (error.error instanceof ErrorEvent || (error.error && error.error.message)) {
      errorMessage = `${error.error.message}`;
    } else if (error.status) {
      errorMessage = `Request failed with ${error.status} ${error.statusText}`;
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
  
    return throwError(() => errorMessage);
}