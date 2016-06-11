open System
open System.IO

let rec longestWord (words: string list) =
    match words with
    | w1::w2::ws ->
        if Seq.length w2 > Seq.length w1 then
            longestWord (w2::ws)
        else
            longestWord (w1::ws)
    | [w] -> w
    | _   -> ""

"some line with text".Split ' '
|> List.ofArray
|> longestWord
|> printfn "%s"


[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split ' '
        |> List.ofArray
        |> longestWord
        |> printfn "%s"
    0
