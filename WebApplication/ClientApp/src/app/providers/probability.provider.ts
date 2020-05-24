import { Injectable } from "@angular/core"
import { HttpClient } from "@angular/common/http"
import { Observable} from "rxjs"
import { map, catchError } from 'rxjs/operators'
import { BaseProvider } from "./BaseProvider"
import { ProbabilityResult } from "../models/probabilityResult"

@Injectable()
export class ProbabilityProvider extends BaseProvider {

    constructor(private http: HttpClient) {
        super()
    }

    public calculateProbability(probabilityOfA: number, probabilityOfB: number): Observable<ProbabilityResult> {

        const url = `${this.apiUrl}/probability?pA=${probabilityOfA}&pB=${probabilityOfB}`

        return this.http.get(url).pipe(
            map(result => this.parseProbability(result)),
            catchError(error => super.handleError<ProbabilityResult>(error)                
        ))
    }


    private parseProbability(res: Object): ProbabilityResult {
        try {
            var isSuccess = res["isSuccess"]
            return isSuccess ?
                ProbabilityResult.Ok(parseFloat(res["probability"])) :
                ProbabilityResult.Error(res["errors"])
        }
        catch {
            throw "Failed to parce the probability request result from JSON response."
        }
    }

}
