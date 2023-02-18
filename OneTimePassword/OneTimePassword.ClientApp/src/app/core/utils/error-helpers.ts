import { HttpErrorResponse } from "@angular/common/http";
import { throwError } from "rxjs";

export function transformError(error: HttpErrorResponse | string) {
    let errorMessage = 'Server error.\n';

    if (typeof error === 'string') {
        errorMessage = error;
    }
    else if (error instanceof HttpErrorResponse) {
        errorMessage = `Server error ${error.status}\n`;
        if (error.message) {
            errorMessage += `${error.message}\n`;
        }
        if (typeof error.error === 'string') {
            errorMessage += `${error.error}\n`;
        }
        else {
            errorMessage += `${error.error.title}\n`;
        }
    }
    else {
        errorMessage += error;
    }
  
    return throwError(() => errorMessage);
}