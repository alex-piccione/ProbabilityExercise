module TestUtils

open Probability.Core.Models

let createRequest probA probB calcType= 
    let request = CalculateProbabilityRequest()
    request.ProbabilityOfA <- probA
    request.ProbabilityOfB <- probB
    request.CalculationType <- calcType
    request

