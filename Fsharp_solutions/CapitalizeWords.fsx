open System
open System.IO

let capitalize (s: string) =
    Char.ToUpper(s.[0]) :: (Seq.skip 1 s |> List.ofSeq)
    |> String.Concat

[<EntryPoint>]
let main(args) =    
    File.ReadLines(args.[0])
    |> Seq.map (fun line ->
                line.Split ' '
                |> Seq.map capitalize
                |> String.concat " ")
    |> Seq.iter (printfn "%s")
    0
