open System
open System.IO

let mthLast (input: string) =
    let chars =
        input.Split ' '
        |> Seq.ofArray
        |> Seq.rev
        |> List.ofSeq
    let n = List.head chars |> Int32.Parse

    List.tail chars
    |> List.tryItem (n - 1)


[<EntryPoint>]
let main(args) =
    File.ReadLines(args.[0])
    |> Seq.map (mthLast)
    |> Seq.choose id
    |> Seq.iter (printfn "%s")
    0
