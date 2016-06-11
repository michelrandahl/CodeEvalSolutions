open System
open System.IO

[<EntryPoint>]
let main(args) =    
    let lines =
        File.ReadLines(args.[0])
        |> List.ofSeq
    let N = List.head lines |> Int32.Parse
    Seq.tail lines
    |> Seq.sortBy (fun l -> Seq.length l)
    |> Seq.rev
    |> Seq.take N
    |> Seq.iter (printfn "%s")
    0
