import { Component } from "@angular/core"
import { ProbabilityProvider } from "../providers/probability.provider"

@Component({
  selector: "probability-page",
  templateUrl: "./probability.page.html",
  styleUrls: ["./probability.page.css"]
})
export class ProbabilityPage {

    public pA: number
    public pB: number
    public error: string=""
    public probabilityResult:number|undefined

    constructor(private probabilityProvider: ProbabilityProvider) {
        this.pA = 0.5;
        this.pB = 0.5;
    }


    /* UI events */
    public calculateProbability() {
        this.error = ""
        this.probabilityResult = undefined

        this.probabilityProvider.calculateProbability(this.pA, this.pB).subscribe(
            result => {
                if (result.isSuccess)
                    this.probabilityResult = result.probability
                else
                    this.error = result.errors.join(", ")
            },
            error => {
                this.error = error
            }
        )
    }

}
