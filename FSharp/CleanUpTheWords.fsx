open System
open System.IO
open System.Text.RegularExpressions


let test = "(--9Hello----World...--)"
let regex = Regex("[a-zA-Z]+")
let ms = regex.Matches(test)


let cleanUpWords messy_text = seq {
    let ms = regex.Matches(messy_text)
    for m in ms do
        yield m.Value
}

cleanUpWords test
|> Seq.map (fun s -> s.ToLower())
|> String.concat " "

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        cleanUpWords test
        |> Seq.map (fun s -> s.ToLower())
        |> String.concat " "
        |> printfn "%s"
    0
