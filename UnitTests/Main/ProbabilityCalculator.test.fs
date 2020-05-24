[<NUnit.Framework.Category("Calculator")>]
module ProbabilityCalculator_test

open NUnit.Framework
open FsUnit
open Probability.Core.Calculators
open Probability.Core.Models
open Probability.Core.Exceptions

let createRequest probA probB = 
    let request = CalculateProbabilityRequest()
    request.ProbabilityOfA <- probA
    request.ProbabilityOfB <- probB
    request


[<TestCase(-0.1, 0)>]
[<TestCase( 1.1, 0)>]
[<TestCase(0, -0.1)>]
[<TestCase(0,  1.1)>]
let ``CalculateProbability [when] probability are out of ranget [should] raise a specific Exception`` (probA:decimal, probB:decimal) =
    let request = createRequest probA probB
    (fun () -> ProbabilityCalculator().CalculateProbability(request) |> ignore)
    |> should throw typeof<InvalidCalculateProbabilityRequest>


[<TestCase(0.5, 0.5, 1.0)>]
let ``CalculateProbability__should__return_correct_value`` (probA:decimal, probB:decimal, expectedResult:decimal) =
    let request = createRequest probA probB
    let result = ProbabilityCalculator().CalculateProbability(request)
    result |> should equal expectedResult

