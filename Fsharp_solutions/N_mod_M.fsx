open System
open System.IO

let mymod n m =
    n - (n / m) * m

[<EntryPoint>]
let main args =
    let inputs = File.ReadLines(args.[0])
    for input in inputs do
        match input.Split ',' with
        | [|n;m|] ->
            mymod (Int32.Parse n) (Int32.Parse m)
            |> printfn "%d"
        | _ -> printfn "error"
    0
