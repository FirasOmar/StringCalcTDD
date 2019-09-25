module Implementation

open System
open System.Linq.Expressions

type  stringCalc () = 
    member  x.Add expression = 
    match expression with
    | "" -> 0
    | _  when expression.Contains "," ->
         [for n in expression.Split[|','|] -> Int32.Parse n] |> List.reduce(fun acc v -> acc + v)
    | _ -> Int32.Parse expression 

