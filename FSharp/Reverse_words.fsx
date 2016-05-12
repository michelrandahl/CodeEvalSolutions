open System
open System.IO

let input = "hello world again"

input.Split ' '
|> Seq.rev
|> Seq.fold (fun acc x -> acc + " " + x) ""
|> Seq.skip 1 |> String.Concat
|> printfn "%s"