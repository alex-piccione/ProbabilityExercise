[<NUnit.Framework.Category("Calculator")>]
module ProbabilityCalculator_test

open NUnit.Framework
open FsUnit
open Probability.Core.Calculators
open Probability.Core.Models

let createInput probA probB= 
    let input = CalculateProbabilityInput()
    input.ProbabilityOfA <- probA
    input.ProbabilityOfB <- probB
    input


[<Category("CombinedWith")>]
[<TestCase(0.5, 0.5, 0.25)>]
[<TestCase(0.1, 0.3, 0.03)>]
let ``CalculateProbability [when] type is CombinedWith [should] calculate the correct value`` 
    (probA:decimal, probB:decimal, expectedResult:decimal) =

    let input = createInput probA probB
    let result = CombinedWithProbabilityCalculator().Calculate(input)
    result |> should equal expectedResult


[<Category("Either")>]
[<TestCase(0.5, 0.5, 0.75)>]
[<TestCase(0.1, 0.3, 0.37)>]
let ``CalculateProbability [when] type is Either [should] calculate the correct value`` 
    (probA:decimal, probB:decimal, expectedResult:decimal) =

    let input = createInput probA probB
    let result = EitherProbabilityCalculator().Calculate(input)
    result |> should equal expectedResult

