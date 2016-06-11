open System
open System.IO


[<EntryPoint>]
let main args =
    let inputs = File.ReadLines(args.[0])
    let sum = inputs |> Seq.map (Int32.Parse) |> Seq.sum
    printfn "%d" sum
    0
