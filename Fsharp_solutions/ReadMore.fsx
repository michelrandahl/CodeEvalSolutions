open System
open System.IO

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        let xs = test.Trim() |> List.ofSeq
        if List.length xs <= 55 then
            printfn "%s" (test.Trim())
        else
            let xs' = xs |> Seq.take 40
            let xs_trimmed =
                if Seq.contains ' ' xs' then
                    xs'
                    |> Seq.rev
                    |> Seq.skipWhile ((<>)' ')
                    |> Seq.skip 1
                    |> Seq.rev
                else
                    xs'
            xs_trimmed
            |> Seq.map string
            |> String.concat ""
            |> printfn "%s... <Read More>"
    0
