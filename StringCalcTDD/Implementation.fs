module Implementation

open System
open System.Linq.Expressions

type  stringCalc () = 
    member  x.Add expression = 
        match expression with
         | "" -> 0
         | _  ->
            [for n in expression.Split[|',';'\n'|] -> Int32.Parse n] |> List.reduce(fun acc v -> acc + v)
    

