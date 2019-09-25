module Implementation

open System
open System.Linq.Expressions

type  stringCalc () = 
    let rec addInternal delimiter expression =
         match expression with
         | "" -> 0
         | _ when expression.StartsWith "//" -> 
             expression.Substring( expression.IndexOf("\n") + 1) |> addInternal [|expression.[2]|]
         | _  ->
            [for n in expression.Split delimiter -> Int32.Parse n] |> List.reduce(fun acc v -> acc + v)
    member  x.Add expression = 
       expression |> addInternal [|',';'\n'|]

