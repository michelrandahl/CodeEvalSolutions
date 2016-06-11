open System
open System.IO

let levenshteinDistance1 (s: string) (t: string) =
    let s' = List.ofSeq s
    let t' = List.ofSeq t
        
    let rec loop (s: char list) (t: char list) =
        let len_s = List.length s
        let len_t = List.length t

        if len_s = 0 then
            len_t
        else if len_t = 0 then
            len_s
        else
            let cost =
                if List.head s = List.head t then 0
                else 1
            let res =
                loop (List.tail  s) t + 1
                |> min (loop s (List.tail t) + 1)
                |> min (loop (List.tail s) (List.tail t) + cost)
            res
    loop s' t'

let w1 = "kitten"
let w2 = "kitten"
levenshteinDistance1 w1 w2

let levenshteinDistance2 (s : string) (t: string) = 
    if s = t then 0
    else
        let len_t = t.Length
        let len_s = s.Length
        let v0 = [0..len_t] |> Array.ofList
        let v1 = [0..len_t] |> Array.ofList

        for i in [0..len_s - 1] do
            v1.[0] <- i + 1
            for j in [0..len_t - 1] do
                let cost = if s.[i] = t.[j] then 0 else 1
                v1.[j + 1] <-
                    v1.[j] + 1
                    |> min (v0.[j + 1] + 1)
                    |> min (v0.[j] + cost)
            Array.Copy(v1, v0, Array.length v0)
        v1.[len_t]

let createGraph (potential_friends_map: Map<int,string list>) =
    let (indexes, pot_friends) =
        potential_friends_map
        |> Map.toList
        |> List.unzip

    let pot_friends' =
        pot_friends
        |> Seq.concat
        |> Seq.sortBy (fun w -> w.Length)
        |> List.ofSeq

    //let max_index = Seq.max indexes
    //let min_index = Seq.min indexes

    let rec loop (pot_friends: string list) (sparse_graph: (string*string) list) =
        match pot_friends with
        | [] -> sparse_graph
        | w::ws ->
            let new_nodes =
                ws
                |> Seq.takeWhile (fun w' -> w'.Length <= w.Length + 1)
                |> Seq.filter (fun w' -> levenshteinDistance2 w w' = 1)
                |> List.ofSeq
            let sparse_graph' =
                [ new_nodes |> List.map (fun w' -> w',w)
                  new_nodes |> List.map (fun w' -> w,w')
                  sparse_graph ]
                |> List.concat
            loop ws sparse_graph'
    loop pot_friends' []

        
let findFriends (initial: string) (potential_friends: string list) =
    let rec loop (potential_friends: string list) (new_friends: string list) = seq {
        match new_friends with
        | [] -> ()
        | f::fs ->
            yield f
            let (new_friends', potential_friends') =
                potential_friends
                |> List.partition (fun f' -> levenshteinDistance2 f f' = 1)
            let fs' =
                new_friends'
                |> List.append fs
            yield! loop potential_friends' fs'
    }
    loop potential_friends [initial]

let solveProblem (file_path: string) =
    //let lines =
    //    File.ReadLines(file_path)
    //    |> Seq.map (fun s -> s.Trim())
    //    |> Seq.filter ((<>)"")
    //    |> List.ofSeq

    let lines =
        File.ReadAllLines(file_path)
        |> Seq.map (fun l -> l.Split ',')
        |> Seq.concat
        |> Seq.map (fun s -> s.Trim())
        |> Seq.filter ((<>)"")
        |> List.ofSeq

    let test_cases = 
        lines
        |> Seq.takeWhile ((<>)"END OF INPUT")
        |> List.ofSeq
    let potential_friends_map =
        lines
        |> Seq.skipWhile ((<>)"END OF INPUT")
        |> Seq.skip 1
        |> Seq.map (fun f -> f.Length,f)
        |> Seq.groupBy fst
        |> Seq.map (fun x -> fst x, snd x |> Seq.map snd |> List.ofSeq)
        |> Map.ofSeq

    createGraph potential_friends_map

    //for test in test_cases do
    //    List.concat [
    //        potential_friends_map.[test.Length] |> List.filter ((<>)test)
    //        potential_friends_map.[test.Length - 1]
    //        potential_friends_map.[test.Length + 1]
    //    ]
    //    |> findFriends test 
    //    |> Set.ofSeq
    //    |> Seq.length
    //    |> printfn "%d"



#time
solveProblem @"C:\Users\michel\Documents\Visual Studio 2015\Projects\CodeEval\CodeEval\levenshtein_testdata2.txt"
#time

(* EXPECTED RESULT
4
2
5
3
3
3
3
4
2
3
3
3
8
1
4
5
3
3
1
3
*)

[<EntryPoint>]
let main(args) =    
    solveProblem args.[0]
    0
