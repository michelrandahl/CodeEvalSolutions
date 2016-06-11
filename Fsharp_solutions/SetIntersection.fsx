open System
open System.IO


"9,10,11;33,34,35".Split ';'
|> Seq.map (fun s -> s.Split ',')
|> Seq.map (Seq.map Int32.Parse)
|> Seq.map (Set.ofSeq)
|> Seq.reduce (Set.intersect) 
|> Seq.map string
|> fun xs ->
    if Seq.length xs = 0 then ""
    else
        xs |> Seq.reduce (fun acc x -> sprintf "%s,%s" acc x)
|> printfn "%s"


[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split ';'
        |> Seq.map (fun s -> s.Split ',')
        |> Seq.map (Seq.map Int32.Parse)
        |> Seq.map (Set.ofSeq)
        |> Seq.reduce (Set.intersect) 
        |> Seq.map string
        |> fun xs ->
            if Seq.length xs = 0 then ""
            else
                xs |> Seq.reduce (fun acc x -> sprintf "%s,%s" acc x)
        |> printfn "%s"
    0
