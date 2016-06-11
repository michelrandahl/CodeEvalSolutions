

[1..99]
|> Seq.filter (fun x -> not(x % 2 = 0))
|> Seq.iter (printfn "%d")