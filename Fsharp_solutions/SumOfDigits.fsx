open System
open System.IO

"1234"
|> List.ofSeq
|> Seq.map string
|> Seq.map (Int32.Parse)
|> Seq.sum

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test
        |> List.ofSeq
        |> Seq.map string
        |> Seq.map (Int32.Parse)
        |> Seq.sum
        |> printfn "%d"
    0
