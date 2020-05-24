import { Observable, throwError } from "rxjs"
import { HttpErrorResponse } from "@angular/common/http"

export class BaseProvider {

    protected apiUrl = `${location.protocol}//${location.host}/api`


    protected handleError<T>(error: any): Observable<T> {

        if (error as HttpErrorResponse)
            return throwError(error.error.title||`${error.status} error` + " " + error.error.detail||"")

        return throwError("Undefined error: " + String(error))
    }

}
