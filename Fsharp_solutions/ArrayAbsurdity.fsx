open System
open System.IO

let rec findDuplicate (item_set: Set<'a>) (input: 'a list) =
    match input with
    | [] -> None
    | x:: xs ->
        if Set.contains x item_set then
            Some(x)
        else
            findDuplicate (Set.add x item_set) xs

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        match test.Split ';' with
        | [|_; arr_string|] ->
            let result = 
                arr_string.Split ','
                |> List.ofArray
                |> findDuplicate (Set.empty<string>)
            match result with
            | Some(x) -> printfn "%s" x
            | None    -> printfn "no duplicates"
        | _ -> printfn "invalid input"
    0
