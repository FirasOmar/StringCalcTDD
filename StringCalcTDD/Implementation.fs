module Implementation

open System
open System.Linq.Expressions

type  stringCalc () = 
    member  x.Add expression = 
    match expression with
    | "" -> 0
    | _ -> Int32.Parse expression 

