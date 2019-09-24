module Tests

open System
open Implementation
open NUnit.Framework

[<TestFixture>]
type stringCalcTests() =

    [<Test>]
    member r.AddEmptyString_ReturnZero () = 
        let calc = stringCalc()
        let result = calc.Add ""
        Assert.That(result,Is.EqualTo 0)




