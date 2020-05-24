import { Injectable } from "@angular/core"
import { HttpClient } from "@angular/common/http"
import { BaseProvider } from "./BaseProvider"
import { Observable} from "rxjs"
import { map, catchError } from 'rxjs/operators'

@Injectable()
export class ProbabilityProvider extends BaseProvider {

    constructor(private http: HttpClient) {
        super()
    }

    public calculateProbability(probabilityOfA: number, probabilityOfB: number): Observable<number> {

        const url = `${this.apiUrl}/probability?pA=${probabilityOfA}&pB=${probabilityOfB}`

        return this.http.get(url).pipe(
            map(result => this.parseProbability(result)),
            catchError(error => super.handleError<number>(error))
        )
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
