open System
open System.IO

let rec fizzbuzz x y n = seq {
    if n % x = 0 && n % y = 0 then
        yield "FB"
    else if n % x = 0 then
        yield "F"
    else if n % y = 0 then
        yield "B"
    else
        yield string n
    yield! fizzbuzz x y (n+1)
}

let (|IntInputArgs|_|) (input: string) =
    match input.Split ' ' with
    | [|X;Y;N|] as xs ->
        let parsed_inputs = xs |> Seq.map Int32.TryParse
        if Seq.forall fst parsed_inputs then
            parsed_inputs
            |> Seq.map snd
            |> List.ofSeq
            |> Some
        else
            None
    | _ -> None

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        match test with
        | IntInputArgs [X;Y;N] ->
            fizzbuzz X Y 1
            |> Seq.take N
            |> Seq.fold (fun acc x -> acc + " " + x) ""
            |> Seq.skip 1 |> String.Concat
            |> printfn "%s"
        | _ -> ()
    0