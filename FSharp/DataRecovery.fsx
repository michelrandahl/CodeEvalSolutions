open System
open System.IO

let parseLine (line: string) =
    match line.Split(';') with
    | [|text;order|] ->
        let order' =
            order.Split(' ')
            |> Seq.map (Int32.TryParse)
            |> Seq.filter fst
            |> Seq.map snd
            |> List.ofSeq
        Some (text, order')
    | _ -> None

let addMissingNumber (n: int) (order: int list) =
    let missing_numbers =
        (Set.ofSeq [1..n], order)
        ||> Seq.fold (fun set x -> Set.remove x set) 
        |> Seq.sort
        |> List.ofSeq
    List.append order missing_numbers

[3;2;1]
|> addMissingNumber 4

let reorder (text: string) (order: int list) =
    let text' = text.Split(' ')
    let num_words = Seq.length text'

    (addMissingNumber num_words order, text')
    ||> Seq.zip
    |> Seq.sortBy fst
    |> Seq.map snd
    |> Seq.fold (fun acc x -> acc + " " + x) ""
    |> Seq.skip 1 |> String.Concat


"""
2000 and was not However, implemented 1998 it until;9 8 3 4 1 5 7 2
programming first The language;3 2 1
programs Manchester The written ran Mark 1952 1 in Autocode from;6 2 1 7 5 3 11 4 8 9
""".Split('\n')
|> Seq.map (fun line -> line.Trim())
|> Seq.filter (fun line -> line <> "")
|> Seq.map parseLine
|> Seq.map (Option.map (fun args -> args ||> reorder))
|> Seq.iter (printfn "%s" |> Option.iter)

