open System
open System.IO

let rec permute xs = seq {
    match xs with
    | x::xs -> 
        for y in xs do
            yield x,y
        yield! permute xs
    | _ -> ()
}

let test = "1,2,3,4,6;5"

match test.Split ';' with
| [|numbers; sum|] ->
    let sum' = Int32.Parse sum
    numbers.Split ','
    |> Seq.map (Int32.Parse)
    |> List.ofSeq
    |> permute
    |> Seq.filter (fun x -> fst x + snd x = sum')
    |> Seq.sortBy fst
    |> Seq.map (fun x -> x ||> sprintf "%d,%d")
    |> String.concat ";"


[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        match test.Split ';' with
        | [|numbers; sum|] ->
            let sum' = Int32.Parse sum
            let numbers' =
                numbers.Split ','
                |> Seq.map (Int32.Parse)
                |> List.ofSeq
                |> permute
                |> Seq.filter (fun x -> fst x + snd x = sum')

            if Seq.length numbers' = 0 then
                printfn "NULL"
            else
                numbers'
                |> Seq.sortBy fst
                |> Seq.map (fun x -> x ||> sprintf "%d,%d")
                |> String.concat ";"
                |> printfn "%s"
        | _ -> ()
    0
