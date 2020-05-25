[<NUnit.Framework.Category("Calculator")>]
module ProbabilityCalculatorSupervisor_test

open NUnit.Framework
open Moq
open FsUnit
open Probability.Core.Calculators
open Probability.Core.Models
open Probability.Core.Exceptions

open Test_utils
open Probability.Core.Contracts

type ProbabilityCalculatorSupervisor_test () =

    let calculatorFactory = Mock<ICalculatorFactory>().Object

    [<TestCase(-0.1, 0)>]
    [<TestCase( 1.1, 0)>]
    [<TestCase(0, -0.1)>]
    [<TestCase(0,  1.1)>]
    member me.``CalculateProbability [when] probability are out of ranget [should] raise a specific Exception`` (probA:decimal, probB:decimal) =
        let request = createRequest probA probB CalculationType.CombinedWith
        (fun () -> ProbabilityCalculatorSupervisor(calculatorFactory).CalculateProbability(request) |> ignore)
        |> should throw typeof<InvalidCalculateProbabilityRequest>


    [<TestCase("")>]
    [<TestCase(null)>]
    member me.``CalculateProbability [when] probability type is unknown [should] raise a specific Exception`` (calcType:string) =
        let request = createRequest 0m 0m calcType
        (fun () -> ProbabilityCalculatorSupervisor(calculatorFactory).CalculateProbability(request) |> ignore)
        |> should throw typeof<InvalidCalculateProbabilityRequest>

