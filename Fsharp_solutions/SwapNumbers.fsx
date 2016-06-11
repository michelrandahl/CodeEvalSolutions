open System.Text.RegularExpressions
open System
open System.IO

let test = "4Always0 5look8 4on9 7the2 4bright8 9side7 3of8 5life5"

let swapNumbers (w: string) =
    let m = Regex("(?<d1>\d+)(?<word>.+)(?<d2>\d+)").Match w
    sprintf "%s%s%s" (m.Groups.["d2"].Value) (m.Groups.["word"].Value) (m.Groups.["d1"].Value)

test.Split ' '
|> Seq.map swapNumbers
|> String.concat " "

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split ' '
        |> Seq.map swapNumbers
        |> String.concat " "
        |> printfn "%s"
    0
