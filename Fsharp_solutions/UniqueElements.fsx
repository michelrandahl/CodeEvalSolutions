open System
open System.IO

let test = "1,1,1,2,2,3,3,4,4"
test.Split ','
|> Seq.ofArray
|> Seq.map (Int32.Parse)
|> Set.ofSeq
|> Seq.sort
|> Seq.map string
|> String.concat ","
|> printfn "%s"

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split ','
        |> Seq.ofArray
        |> Seq.map (Int32.Parse)
        |> Set.ofSeq
        |> Seq.sort
        |> Seq.map string
        |> String.concat ","
        |> printfn "%s"
    0
