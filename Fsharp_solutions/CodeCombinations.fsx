open System
open System.IO

let input =
    """
    **** | *co* | *de* | ****
    codx | decx
    co | dx
    """

let code = "code" |> Set.ofSeq

"codx | decx".Split '|'
|> Seq.map (fun r -> r.Trim() |> List.ofSeq |> List.windowed 2)
|> Seq.windowed 2
|> Seq.map (fun win -> Seq.zip win.[0] win.[1])
|> Seq.concat
|> Seq.map (fun seqs -> fst seqs |> Set.ofSeq, snd seqs |> Set.ofSeq)
|> Seq.map (fun sets -> sets ||> Set.union)
|> Seq.filter (fun set -> set = code)
|> Seq.length


[<EntryPoint>]
let main(args) =
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split('|')
        |> Seq.map (fun r -> r.Trim() |> List.ofSeq |> List.windowed 2)
        |> Seq.windowed 2
        |> Seq.map (fun win -> Seq.zip win.[0] win.[1])
        |> Seq.concat
        |> Seq.map (fun seqs -> fst seqs |> Set.ofSeq, snd seqs |> Set.ofSeq)
        |> Seq.map (fun sets -> sets ||> Set.union)
        |> Seq.filter (fun set -> set = code)
        |> Seq.length
        |> printfn "%d"
    0
