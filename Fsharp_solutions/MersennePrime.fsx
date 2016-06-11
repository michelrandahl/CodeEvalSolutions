open System
open System.IO

let log2 x = Math.Log x / Math.Log 2.0

let x = log2 521.0 

let rec primeNumbers n = seq {
    match n with
    | 0|1 -> ()
    | 2|3 -> yield n
    | n when n % 2 = 0 || n % 3 = 0 -> ()
    | n -> 
        let rec primeTest i = 
            if i*i <= n then
                if n % i = 0 || n % (i+2) = 0 then
                    false
                else primeTest (i+1)
            else true
        if primeTest 5 then
            yield n
    yield! primeNumbers (n+1)
}

let mersennePrimes n = 
    primeNumbers 1
    |> Seq.takeWhile (fun p -> p <= n)
    |> Seq.filter
        (fun p ->
            let p' = float p
            let power = log2 p' |> Math.Ceiling
            2.0**power - 1.0 = p' ||
            2.0**(power - 1.0) - 1.0 = p'
        )


let n = 3000.0
primeNumbers 1
|> Seq.map (fun p -> 2.0**float(p) - 1.0)
|> Seq.takeWhile (fun m -> m <= n)
|> Seq.map string
|> String.concat ", "
|> printfn "%s"

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        let n = float(Int32.Parse test)
        primeNumbers 1
        |> Seq.map (fun p -> 2.0**float(p) - 1.0)
        |> Seq.takeWhile (fun m -> m <= n)
        |> Seq.map string
        |> String.concat ", "
        |> printfn "%s"
    0

