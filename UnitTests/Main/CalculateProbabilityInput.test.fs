[<NUnit.Framework.Category("Calculator")>]
module CalculateProbabilityInput_test

open NUnit.Framework
open FsUnit
open Probability.Core.Models

[<Test>]
let FromCalculateProbabilityRequest() =
    let request = Test_utils.createRequest 1m 2m "type"
    let input = CalculateProbabilityInput.FromCalculateProbabilityRequest(request)
    input |>  should not' (be Null)
    input.ProbabilityOfA |> should equal 1m
    input.ProbabilityOfB |> should equal 2m

