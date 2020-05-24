import { Observable, throwError } from "rxjs"
import { HttpErrorResponse } from "@angular/common/http"

export class BaseProvider {

  protected apiUrl = `${location.protocol}//${location.host}/api`

  //protected handleError<T>(error: any): Observable<T> {

    protected handleError<T>(error: any): Observable<T> {

        if (error as HttpErrorResponse)
            if (error.status == 500)
                return throwError(error.error.title || "500 error")
            else 
                return throwError(error.error.title || "Eror " + error.status + ": " + String(error))

        return throwError("Undefined error")
    }

}
