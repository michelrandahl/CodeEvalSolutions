open System
open System.IO


let test = "9 0 6 | 15 14 9"

test.Split '|'
|> Seq.map (fun s -> s.Split ' ')
|> Seq.map (Seq.filter ((<>)""))
|> Seq.map (Seq.map Int32.Parse)
|> fun xs -> Seq.head xs, Seq.head (Seq.tail xs)
||> Seq.zip
|> Seq.map (fun x -> fst x * snd x)
|> Seq.map string
|> String.concat " "

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split '|'
        |> Seq.map (fun s -> s.Split ' ')
        |> Seq.map (Seq.filter ((<>)""))
        |> Seq.map (Seq.map Int32.Parse)
        |> fun xs -> Seq.head xs, Seq.head (Seq.tail xs)
        ||> Seq.zip
        |> Seq.map (fun x -> fst x * snd x)
        |> Seq.map string
        |> String.concat " "
        |> printfn "%s"
    0
