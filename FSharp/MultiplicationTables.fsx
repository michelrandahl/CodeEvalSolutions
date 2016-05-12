open System
open System.IO

[1..12]
|> Seq.map (fun x -> [|for y in 1..12 -> (sprintf "%d" (x*y)).PadLeft(4)|])
|> Seq.map (fun xs -> String.Join("", xs))
|> Seq.map (fun s -> s.TrimEnd())
|> Seq.iter (printfn "%s")