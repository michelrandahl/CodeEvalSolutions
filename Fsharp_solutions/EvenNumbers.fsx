open System
open System.IO

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        if (Int32.Parse test) % 2 = 0 then
            printfn "1"
        else
            printfn "0"
    0