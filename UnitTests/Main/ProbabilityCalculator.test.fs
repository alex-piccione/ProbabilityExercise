module ProbabilityCalculator_test

open NUnit.Framework
open FsUnit
open Probability.Core.Calculators
open Probability.Core.Models

let createRequest probA probB = 
    let request = CalculateProbabilityRequest()
    request.ProbabilityOfA <- probA
    request.ProbabilityOfB <- probB
    request

[<TestCase(0.5, 0.5, 1.0)>]
let ``CalculateProbability__when__NoKind_IsPassed`` (probA:decimal, probB:decimal, expectedResult:decimal) =
    let request = createRequest probA probB
    let result = ProbabilityCalculator().CalculateProbability(request)
    result |> should equal expectedResult

