open System
open System.IO
open System.Text.RegularExpressions

let test = "<-->>"
let regex = Regex "(?=(\<--\<\<))|(?=(\>\>--\>))"
let xs = regex.Matches test
xs.Count


[<EntryPoint>]
let main args =
    args.[0]
    |> File.ReadLines
    |> Seq.map (regex.Matches)
    |> Seq.map (fun x -> x.Count)
    |> Seq.iter (printfn "%d")
    0

