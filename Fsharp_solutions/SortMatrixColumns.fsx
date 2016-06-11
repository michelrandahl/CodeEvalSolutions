open System
open System.IO

let parseLine (line: string) : int [] list   =
    line.Split '|'
    |> Seq.map (fun s -> s.Trim().Split ' ')
    |> Seq.map (Seq.map Int32.Parse)
    |> Seq.map (Array.ofSeq)
    |> List.ofSeq

let rec maskStable = function
| [] -> true
| xs when List.length xs = 1 -> true
| x::y::xs ->
    if x = y then
        false
    else maskStable (y::xs)

let sortMatrixColumns (matrix: int [] list) = seq {
    let N = List.length matrix
    let mask, first_row_sorted = 
        List.head matrix
        |> Array.zip [|0..N-1|]
        |> Array.sortBy snd
        |> Array.unzip
    yield first_row_sorted

    let rec loop (matrix: int [] list) (mask: int []) (mask_stable: bool) (prev_row: int []) = seq {
        match matrix with
        | [] -> ()
        | row::matrix ->
            let row_ordered_by_mask = [|for i in [0..N-1] -> row.[mask.[i]]|]
            if mask_stable then
                yield row_ordered_by_mask
                yield! loop matrix mask mask_stable row_ordered_by_mask
            else
                let sorted_row, mask' =
                    [|for i in [0..N-1] -> row.[mask.[i]], mask.[i]|]
                    |> Array.zip prev_row 
                    |> Array.groupBy fst
                    |> Array.map snd
                    |> Array.map (Array.map snd)
                    |> Array.map (Array.sortBy fst)
                    |> Array.concat
                    |> Array.unzip
                let mask_stable' = maskStable(List.ofArray sorted_row)
                yield sorted_row
                yield! loop matrix mask' mask_stable' sorted_row
    }
    let mask_stable = maskStable(List.ofArray first_row_sorted)
    yield! loop (List.tail matrix) mask mask_stable first_row_sorted
}

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        parseLine test
        |> sortMatrixColumns
        |> Seq.map (Seq.map string >> String.concat " ")
        |> String.concat " | "
        |> printfn "%s" 
    0
