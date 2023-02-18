import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable } from "rxjs";
import { GeneratedPasswordModel, UserOtpRequestModel } from "../models/generated-password.model";
import { transformError } from "../utils/error-helpers";

@Injectable({
    providedIn: 'root'
})
export class OneTimePasswordService {

    constructor(private httpClient: HttpClient) { }

    getPassword(userOtpRequest: UserOtpRequestModel): Observable<GeneratedPasswordModel> {
        return this.httpClient.post<GeneratedPasswordModel>(`api/PasswordGenerator/GetCurrentPassword`, userOtpRequest)
            .pipe(
                map(response => { return response; }),
                catchError(transformError)
            );
    }
}