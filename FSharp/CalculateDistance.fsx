open System
open System.IO
open System.Text.RegularExpressions


type Point = float * float

let euclidianDistance p1 p2 =
    (fst p1 - fst p2)**2.0 + (snd p1 - snd p2)**2.0
    |> Math.Sqrt


let parseInput text =
    let regex = Regex("\((?<fst_p1>-?\d+), (?<snd_p1>-?\d+)\) \((?<fst_p2>-?\d+), (?<snd_p2>-?\d+)\)")
    let m = (regex.Match text)
    if m.Success then
        let parse (mg: GroupCollection) (k1: string) (k2: string) : Point =
            Double.Parse(mg.[k1].Value), Double.Parse(mg.[k2].Value)
        let mg = m.Groups
        let p1 = parse mg "fst_p1" "snd_p1"
        let p2 = parse mg "fst_p2" "snd_p2"
        Some(p1, p2)
    else None

let test = "(25, 4) (1, -6)"
match parseInput test with
| Some(ps) ->
    ps ||> euclidianDistance
    |> int
    |> printfn "%A"
| None -> ()


[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        match parseInput test with
        | Some(ps) ->
            ps ||> euclidianDistance
            |> int
            |> printfn "%A"
        | None -> ()
    0
