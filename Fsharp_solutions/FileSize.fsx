open System
open System.IO

[<EntryPoint>]
let main(args) =    
    FileInfo(args.[0]).Length
    |> printfn "%d"
    0
