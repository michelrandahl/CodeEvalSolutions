open System
open System.IO

let rec primenumbers n = seq {
    match n with
    | 0|1 -> ()
    | 2|3 -> yield n
    | n when n % 2 = 0 || n % 3 = 0 -> ()
    | n ->
        let rec primetest i =
            if i*i <= n then
                if n % i = 0 || n % (i+2) = 0 then
                    false
                else primetest (i+1)
            else true
        if primetest 5 then
            yield n
    yield! primenumbers (n+1)
}

let countPrimes lower upper =
    primenumbers lower
    |> Seq.takeWhile (fun p -> p <= upper)
    |> Seq.length


[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        match test.Split ',' with
        | [|l;u|] ->
            (Int32.Parse l, Int32.Parse u)
            ||> countPrimes
            |> printfn "%d"
        | _ -> printfn "weird input"
    0
