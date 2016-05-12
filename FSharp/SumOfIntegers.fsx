open System
open System.IO

let permutations (xs: int list) = seq {
    let N = List.length xs
    for to_take in 1..N do
        for to_skip in 0..N do
            if to_take + to_skip <= N then
                let res = 
                    List.skip to_skip xs
                    |> List.take to_take
                yield res
}

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split ','
        |> Seq.map (Int32.Parse)
        |> List.ofSeq
        |> permutations
        |> Seq.map (Seq.sum)
        |> Seq.max
        |> printfn "%d"
    0
