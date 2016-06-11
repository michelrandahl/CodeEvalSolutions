

"hello"
|> List.ofSeq
|> List.permute (fun i -> (i+1) % 5)

let permute (str: string) (n: int) =
    str
    |> List.ofSeq
    |> List.permute (fun i -> (i+n) % (Seq.length str))


let allPermutations (str: string) =
    ([for n in 1..(Seq.length str) -> permute str n],
     [for n in 1..(Seq.length str) -> permute str (-n)])


"hat"
|> allPermutations

