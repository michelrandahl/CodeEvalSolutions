open System
open System.IO

let rec fibonnaci = function
| 0 -> 0
| 1 -> 1
| n -> fibonnaci (n-1) + fibonnaci (n-2)

[for x in 0..10 -> fibonnaci x]

let fib n = 
    let rec loop n1 n2 count =
        if count = n then n2
        else
            if count = 0 then loop 0 1 1
            else loop n2 (n1+n2) (count+1)
    loop 0 0 0
            
[for x in 0..10 -> fib x]

let eval testcase = 
    match Int32.TryParse testcase with
    | false,_ -> ()
    | true, n -> printfn "%d" <| fib n

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        eval test
    0
