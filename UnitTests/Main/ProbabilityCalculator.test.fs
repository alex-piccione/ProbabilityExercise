[<NUnit.Framework.Category("Calculator")>]
module ProbabilityCalculator_test

open NUnit.Framework
open FsUnit
open Probability.Core.Calculators
open Probability.Core.Models
open Probability.Core.Exceptions

let createRequest probA probB probType= 
    let request = CalculateProbabilityRequest()
    request.ProbabilityOfA <- probA
    request.ProbabilityOfB <- probB
    request.ProbabilityType <- probType
    request


[<TestCase(-0.1, 0)>]
[<TestCase( 1.1, 0)>]
[<TestCase(0, -0.1)>]
[<TestCase(0,  1.1)>]
let ``CalculateProbability [when] probability are out of ranget [should] raise a specific Exception`` (probA:decimal, probB:decimal) =
    let request = createRequest probA probB ProbabilityType.CombinedWith
    (fun () -> ProbabilityCalculator().CalculateProbability(request) |> ignore)
    |> should throw typeof<InvalidCalculateProbabilityRequest>


[<TestCase("")>]
[<TestCase(null)>]
let ``CalculateProbability [when] probability type is unknown [should] raise a specific Exception`` (probType:string) =
    let request = createRequest 0m 0m probType
    (fun () -> ProbabilityCalculator().CalculateProbability(request) |> ignore)
    |> should throw typeof<InvalidCalculateProbabilityRequest>


[<TestCase(0.5, 0.5, 1.0)>]
let ``CalculateProbability [should] calculate the correct value`` (probA:decimal, probB:decimal, expectedResult:decimal) =
    let request = createRequest probA probB ProbabilityType.CombinedWith
    let result = ProbabilityCalculator().CalculateProbability(request)
    result |> should equal expectedResult

