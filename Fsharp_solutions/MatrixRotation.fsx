open System
open System.IO

let createMatrix (input: string) = 
    let input_arr = input.Split ' '
    let N = Math.Sqrt(Array.length input_arr |> float) |> int
    input_arr
    |> Seq.chunkBySize N
    |> Array.ofSeq

let rotateMatrix (matrix: string [] []) = seq {
    for i in 0..(Array.length matrix - 1) do
        let row = 
            [for r in matrix -> r.[i]]
            |> Seq.rev
        yield row
}

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test
        |> createMatrix
        |> rotateMatrix
        |> Seq.concat
        |> String.concat " "
        |> printfn "%s"
    0