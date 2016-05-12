open System.Text.RegularExpressions
open System
open System.IO

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        match test.Split ',' with
        | [|sentence;word|] -> 
            let m = Regex(word + "$").Match(sentence)
            if m.Success then
                printfn "%d" 1
            else
                printfn "%d" 0
        | _ -> printfn "%d" 0
    0
