open System
open System.IO

let test = "AD 2H | H"
let test2 = "KD KH | C"
let test3 = "JH 10S | C"

let inline parseCard card =
    match card with
    | "J"    -> 11
    | "Q"    -> 12
    | "K"    -> 13
    | "A"    -> 14
    | number -> Int32.Parse number

let compareSimple (card1: string) (card2: string) =
    let c1 = card1
             |> Seq.take (Seq.length card1 - 1)
             |> Seq.map string
             |> String.concat ""
             |> parseCard
    let c2 = card2
             |> Seq.take (Seq.length card2 - 1)
             |> Seq.map string
             |> String.concat ""
             |> parseCard
    if c1 = c2 then (sprintf "%s %s" card1 card2)
    else if c1 < c2 then card2
    else card1

let simpleOrTrump (input: string) =
    match input.Split '|' |> Array.map (fun s -> s.Trim()) with
    | [|cards; trump|] ->
        let trump_char = Seq.last trump
        match cards.Split ' ' with
        | [|card1;card2|] ->
            let card1_is_trump = Seq.last card1 = trump_char
            let card2_is_trump = Seq.last card2 = trump_char
            if card1_is_trump && card2_is_trump then
                compareSimple card1 card2
            else if card1_is_trump then card1
            else if card2_is_trump then card2
            else compareSimple card1 card2
        | _ -> raise <| Exception("unexpected input")
    | _ -> raise <| Exception("unexpected input")
                

simpleOrTrump test3

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        simpleOrTrump test
        |> printfn "%s"
    0
