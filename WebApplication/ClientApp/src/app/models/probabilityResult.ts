export class ProbabilityResult {
    public isSuccess: boolean
    public errors: string[]
    public probability: number|undefined

    private constructor(isSuccess: boolean, errors: string[], probability: number|undefined) {
        this.isSuccess = isSuccess
        this.errors = errors
        this.probability = probability
    }

    public static Ok = (probability: number) => new ProbabilityResult(true, [], probability)
    public static Error = (errors:string[]) => new ProbabilityResult(false, errors, undefined)
}
