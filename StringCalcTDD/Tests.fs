module Tests

open System
open Implementation
open NUnit.Framework

[<TestFixture>]
type stringCalcTests() =

    [<Test>]
    member r.AddEmptyString_ReturnsZero () = 
        let calc = stringCalc()
        let result = calc.Add ""
        Assert.That(result,Is.EqualTo 0)

    [<TestCase("1",ExpectedResult = 1)>]
    member  r.AddSingleNumber_ReturnsSameNumber expression = 
        let calc = stringCalc()
        calc.Add expression

    [<TestCase("1,2",ExpectedResult = 3)>]
    member  r.AddTwoNumbersWithCommaDelimiter_ReturnsSummation expression = 
        let calc = stringCalc()
        calc.Add expression

    [<TestCase("1,2,3",ExpectedResult = 6)>]
    member  r.AddMoreThanTwoNumbersWithCommaDelimiter_ReturnsSummation expression = 
        let calc = stringCalc()
        calc.Add expression

    [<TestCase("1\n 2,3",ExpectedResult = 6)>]
    member  r.AddMoreThanTwoNumbersWithMultipleDelimiter_ReturnsSummation expression = 
        let calc = stringCalc()
        calc.Add expression
        


