[<NUnit.Framework.Category("Calculator")>]
module ICalculatorFactory_test

open NUnit.Framework
open FsUnit

open Probability.Core.Calculators
open Probability.Core.Models

[<Test>]
let GetCalculator() =

    CalculatorFactory().GetCalculator(CalculationType.CombinedWith)
    |> should be instanceOfType<CombinedWithProbabilityCalculator>

    CalculatorFactory().GetCalculator(CalculationType.Either)
    |> should be instanceOfType<EitherProbabilityCalculator>