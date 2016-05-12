open System
open System.IO

let createSoduko (input: string) =
    match input.Split ';' with
    | [|N;numbers|] ->
        let N' = Int32.Parse N
        numbers.Split ','
        |> Seq.chunkBySize N'
        |> Array.ofSeq
    | _             -> Exception("invalid input") |> raise

let rec checkRows (matrix: 'a [] list) =
    match matrix with
    | [] -> true
    | row::rows ->
        if Set.count (Set.ofArray row) = Array.length row then
            checkRows rows
        else false

let getColumns (matrix: 'a [] []) = seq {
    for i in 0..(Array.length matrix - 1) do
        yield [|for row in matrix -> row.[i]|]
}

let checkColumns (matrix: 'a [] []) =
    getColumns matrix
    |> List.ofSeq
    |> checkRows

let getSquares (matrix: 'a [] []) = 
    let N = Array.length matrix
    let n = int <| Math.Sqrt(float N)
    matrix
    |> Array.map (Array.chunkBySize n)
    |> Array.chunkBySize n
    |> Seq.map (fun xs ->
        xs
        |> getColumns
        |> Seq.map (Seq.concat))
    |> Seq.concat
    |> List.ofSeq
    |> List.map (Array.ofSeq)

let checkSquares (matrix: 'a [] []) =
    getSquares matrix
    |> checkRows

let checkSudoku (input: string) =
    let sudoku = createSoduko input
    checkRows (List.ofArray sudoku) && checkColumns sudoku && checkSquares sudoku


[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        if checkSudoku test then
            printfn "True"
        else
            printfn "False"
    0

