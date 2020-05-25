[<NUnit.Framework.Category("Calculator")>]
module ProbabilityCalculatorSupervisor_test

open System
open NUnit.Framework
open Moq
open FsUnit
open Probability.Core.Calculators
open Probability.Core.Models
open Probability.Core.Exceptions
open Probability.Core.Contracts
open TestUtils

type ProbabilityCalculatorSupervisor_test () =

    let calculatorFactory = Mock<ICalculatorFactory>().Object
    let calculationsStorer = Mock<ICalculationStorer>().Object

    [<TestCase(-0.1, 0)>]
    [<TestCase( 1.1, 0)>]
    [<TestCase(0, -0.1)>]
    [<TestCase(0,  1.1)>]
    member me.``CalculateProbability [when] probability are out of ranget [should] raise a specific Exception`` (probA:decimal, probB:decimal) =
        let request = createRequest probA probB CalculationType.CombinedWith
        (fun () -> ProbabilityCalculatorSupervisor(calculatorFactory, calculationsStorer).CalculateProbability(request) |> ignore)
        |> should throw typeof<InvalidCalculateProbabilityRequest>


    [<TestCase("")>]
    [<TestCase(null)>]
    member me.``CalculateProbability [when] probability type is unknown [should] raise a specific Exception`` (calcType:string) =
        let request = createRequest 0m 0m calcType
        (fun () -> ProbabilityCalculatorSupervisor(calculatorFactory, calculationsStorer).CalculateProbability(request) |> ignore)
        |> should throw typeof<InvalidCalculateProbabilityRequest>


    [<Test>]
    member me.``CalculateProbability [when] calculation is excuted [should] store the calculation data`` () =
        let request = createRequest 0.1m 0.2m CalculationType.CombinedWith
        let start = DateTime.UtcNow
        let calculationResult = 0.3m

        let calculator = Mock<IProbabilityCalculator>()
        calculator.Setup(fun c -> c.Calculate(It.IsAny<CalculateProbabilityInput>())).Returns(calculationResult) |> ignore
        
        let calculatorFactory = Mock<ICalculatorFactory>()        
        calculatorFactory.Setup(fun f -> f.GetCalculator(It.IsAny<string>())).Returns(calculator.Object) |> ignore

        let calculationsStorer = Mock<ICalculationStorer>()

        let verifyCalculation (calc:ExecutedCalculation) =
            calc.When |> should be (greaterThan start)
            calc.Input.ProbabilityOfA |> should equal request.ProbabilityOfA 
            calc.Input.ProbabilityOfB |> should equal request.ProbabilityOfB
            calc.CalculationType |> should equal request.CalculationType
            calc.Result |> should equal calculationResult
            

        calculationsStorer.Setup(fun s -> s.StoreCalculation( It.IsAny<ExecutedCalculation>()))
                              .Callback<ExecutedCalculation>( fun calc -> verifyCalculation(calc)).Verifiable()

        // execute
        let calculatedProbability = ProbabilityCalculatorSupervisor(calculatorFactory.Object, calculationsStorer.Object).CalculateProbability(request) 
        

        calculatedProbability |> should equal calculationResult
        calculationsStorer.Verify(fun s -> s.StoreCalculation( It.IsAny<ExecutedCalculation>()) );

