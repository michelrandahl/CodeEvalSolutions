open System
open System.IO

type Stack<'T> = EmptyStack
               | StackElems of 'T * Stack<'T>
    
let rec pushMany (s: Stack<'T>) (elems: 'T list) =
    match elems with
    | [] -> s
    | e::es ->
        (StackElems(e, s), es)
        ||> pushMany

let rec popEverySecond counter (s: Stack<'T>) = seq {
    match s with
    | EmptyStack -> ()
    | StackElems(e, s') ->
        if counter % 2 = 0 then
            yield e
        yield! popEverySecond (counter+1) s'
}

let test = "1 2 3 4"

test.Split ' '
|> List.ofArray
|> pushMany EmptyStack
|> popEverySecond 0
|> String.concat " "

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test.Split ' '
        |> List.ofArray
        |> pushMany EmptyStack
        |> popEverySecond 0
        |> String.concat " "
        |> printfn "%s"
    0
