import { Injectable, ErrorHandler } from "@angular/core"
import { HttpClient, HttpErrorResponse } from "@angular/common/http"
import { BaseProvider } from "./BaseProvider"
import { Observable, throwError} from "rxjs"
import { map, catchError } from 'rxjs/operators'

@Injectable()
export class ProbabilityProvider extends BaseProvider {

    constructor(private http: HttpClient) {
        super()
    }

    public calculateProbability(probabilityOfA: number, probabilityOfB: number): Observable<number> {

        // client input validation
        //if (probabilityOfA + probabilityOfB == 0)
        //    return throwError("Please select at least a probability higher than zero")

        const url = `${this.apiUrl}/probability?pA=${probabilityOfA}&pB=${probabilityOfB}`

        return this.http.get(url).pipe(
            map(result => this.parseProbability(result)),
            //catchError(error => throwError(error))
            catchError(error => super.handleError<number>(error))
        )

        //http$
        //  .pipe(
        //    catchError(err => of(0))
        //  )
        //  .subscribe(
        //    res => this.parseProbability(res),
        //    err => console.log('HTTP Error', err),
        //    () => console.log('HTTP request completed.')
        //  );
    }


    private parseProbability(res: Object): number {
        try {
            return parseFloat(res["probability"])
        }
        catch {
            throw "Failed to read the probability value from JSON response."
        }
    }

}
