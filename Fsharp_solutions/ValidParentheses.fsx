open System
open System.IO

let test = "([)]"

let verifyParentheses (xs: char list) =
    let rec loop xs stack =
        match xs with
        | [] when stack = [] -> true
        | x :: xs when x = '(' || x = '[' || x = '{' ->
            let stack' = x :: stack
            loop xs stack'
        | ')' :: xs ->
            match stack with
            | '('::stack -> loop xs stack
            | _ -> false
        | ']'::xs ->
            match stack with
            | '['::stack -> loop xs stack
            | _ -> false
        | '}'::xs ->
            match stack with
            | '{'::stack -> loop xs stack
            | _ -> false
        | _ -> false
    loop xs []

test
|> List.ofSeq
|> verifyParentheses

"()"
|> List.ofSeq
|> verifyParentheses

[<EntryPoint>]
let main(args) =    
    File.ReadLines(args.[0])
    |> Seq.map(fun xs ->
               xs
               |> List.ofSeq
               |> verifyParentheses,
               xs)
    //|> Seq.iter (printfn "%A")
    |> Seq.iter (fun res -> if res then printfn "True" else printfn "False")
    0
