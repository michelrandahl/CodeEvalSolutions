
(*
A letter may be replaced by itself. Spaces are left as-is. 
 For example (and here is a hint!), our translation algorithm includes the following three mappings: 'b' -> 'n', 'j' -> 'u', and 'v' -> 'g' is based on the best possible replacement mapping
*)

let encrypted = "rbc vjnmkf kd yxyqci na rbc zjkfoscdd ew rbc ujllmcp"
let decrypted = "the public is amazed by the quickness of the juggler"

let zipped_map =
    (Seq.concat (encrypted.Split ' '), Seq.concat (decrypted.Split ' '))
    ||> Seq.zip
    |> List.ofSeq
    |> Map.ofList

Map.toList zipped_map
|> List.map fst
|> printfn "%A"

Map.toList zipped_map
|> List.map snd
|> printfn "%A"

Map.toList zipped_map
|> Seq.map (fun xs -> fst xs |> int, snd xs |> int)
|> Seq.map (fun xs -> fst xs - snd xs)
|> Seq.map int
|> List.ofSeq
