module Implementation

open System
open System.Linq.Expressions
open System.Text.RegularExpressions

type NegativeNotAllowed(negatives)=
    inherit Exception(sprintf "negative numbers not allowed %A" negatives)

type  stringCalc () = 
    let rec addInternal delimiter expression =
         match expression with
         | "" -> 0
         | _ when expression.StartsWith "//[" ->
             let s = Regex.Replace(expression,@"[\d-]",",").Replace("-",",").ToCharArray()
             let numbers = expression.Split(s,StringSplitOptions.RemoveEmptyEntries)
             numbers|>Seq.map Int32.Parse |> Seq.sum
         | _ when expression.StartsWith "//" -> 
             expression.Substring( expression.IndexOf("\n") + 1) |> addInternal [|expression.[2]|]
         | _  ->
            let negatives, positives = 
                [for n in expression.Split delimiter -> Int32.Parse n] |> List.partition( fun n-> n < 0)
            if negatives.Length > 0 then raise (NegativeNotAllowed negatives)
            else 
                positives |> List.filter(fun n -> n < 1000 ) |> List.reduce(fun acc v  -> acc + v)
    member  x.Add expression = 
       expression |> addInternal [|',';'\n'|]

