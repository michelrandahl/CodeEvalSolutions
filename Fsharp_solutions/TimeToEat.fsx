open System
open System.IO

let test = "02:26:31 14:44:45 09:53:27"

let time = DateTime.Parse test

printfn "%A" time

test.Split ' '
|> Seq.map (DateTime.Parse)
|> Seq.sortDescending
|> Seq.map (fun d -> d.ToString("HH:mm:ss"))
|> String.concat " "


[<EntryPoint>]
let main args =
    args.[0]
    |> File.ReadLines
    |> Seq.map (fun line ->
                line.Split ' '
                |> Seq.map (DateTime.Parse)
                |> Seq.sortDescending
                |> Seq.map (fun d -> d.ToString("HH:mm:ss"))
                |> String.concat " ")
    |> Seq.iter (printfn "%s")
    0
