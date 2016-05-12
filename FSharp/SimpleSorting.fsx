open System
open System.IO

"70.920 -38.797 14.354 99.323 90.374 7.581".Split ' '
|> Seq.map Double.Parse
|> Seq.sort
|> Seq.fold (fun acc x -> sprintf "%s %.3f" acc x) ""
|> Seq.skip 1 |> String.Concat


[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split ' '
        |> Seq.map Double.Parse
        |> Seq.sort
        |> Seq.fold (fun acc x -> sprintf "%s %.3f" acc x) ""
        |> Seq.skip 1 |> String.Concat
        |> printfn "%s"
    0
