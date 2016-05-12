open System
open System.IO

let all_letters =
    "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    |> Array.ofSeq
let N = Array.length all_letters

let bounded_by (N: int) (x: int) =
    if x = 0 then
        N - 1
    else x
        

let rec numberToExcel (input: int) = seq {
    if input < N then
        yield all_letters.[input]
    else if input > 0 then
        let div = input / N
        let m = input % N
        yield all_letters.[m]
        yield! numberToExcel (input - (div * N + m))
}
        
numberToExcel (3702)
|> Seq.take 5

let input = 52

let div = (input - 1) / N
let m = input % N
all_letters.[m]
let input' = input - (div * N + m)

let n' = input - (div * N + m)
let x' = bounded_by N (n' % N)
all_letters.[x']

let n'' = n' - (0 + x')


