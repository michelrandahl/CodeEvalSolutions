open System
open System.IO

let inline permute xs =
    let rec loop xs ys = seq {
        match xs with
        | x :: xs ->
            if List.length ys < 4 then
                yield! loop xs ys

                if List.length ys = 3 then yield x :: ys
                else yield! loop xs (x :: ys)
        | _ -> ()
        }
    loop xs []

[<EntryPoint>]
let main(args) =
    let test_cases = File.ReadLines(args.[0])
    for test in test_cases do
        test.Split ','
        |> Seq.map (Int16.Parse)
        |> List.ofSeq
        |> permute
        |> Seq.filter (fun xs -> List.sum xs = 0s)
        |> Seq.length
        |> printfn "%d"
    0
