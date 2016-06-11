open System
open System.IO

let morsemap = Map.ofList [
    (".-", 'A')
    ("-...", 'B')
    ("-.-.", 'C')
    ("-..", 'D')
    (".", 'E')
    ("..-.", 'F')
    ("--.", 'G')
    ("....", 'H')
    ("..", 'I')
    (".---", 'J')
    ("-.-", 'K')
    (".-..", 'L')
    ("--", 'M')
    ("-.", 'N')
    ("---", 'O')
    (".--.", 'P')
    ("--.-", 'Q')
    (".-.", 'R')
    ("...", 'S')
    ("-", 'T')
    ("..-", 'U')
    ("...-", 'V')
    (".--", 'W')
    ("-..-", 'X')
    ("-.--", 'Y')
    ("--..", 'Z')

    ("", ' ')

    (".----", '1')
    ("..---", '2')
    ("...--", '3')
    ("....-", '4')
    (".....", '5')
    ("-....", '6')
    ("--...", '7')
    ("---..", '8')
    ("----.", '9')
    ("-----", '0')
]

let decode input =
    match Map.tryFind input morsemap with
    | Some letter -> Some letter
    | _      -> None

let eval (input: string) =
    input.Split ' '
    |> Seq.map (fun x -> match decode x with
                         | Some letter -> letter
                         | None -> '#')

let code = ".- -.... -. .---- --- --... ... --.. -.. --.  -.-- ----- ..-. ... --"
let decoded = eval code

code.Split ' '

(code.Split ' ', decoded)
||> Seq.zip
|> List.ofSeq
|> Seq.filter (fun x -> snd x = '#')

".- -.... -. .---- --- --... ... --.. -.. --.  -.-- ----- ..-. ... --"
|> eval
|> Array.ofSeq
|> String.Concat

[<EntryPoint>]
let main(args) =    
    let testCases = File.ReadLines(args.[0])
    for test in testCases do
        test
        |> eval
        |> Array.ofSeq
        |> String.Concat
        |> printfn "%s"
    0