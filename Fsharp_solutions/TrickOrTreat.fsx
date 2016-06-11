open System
open System.IO
open System.Text.RegularExpressions

type CandyDist = {
    vampire_candy : int
    zombie_candy  : int
    witch_candy   : int
    }

type DressedKids = {
    vampires : int
    zombies  : int
    witches  : int
    }

let parseLine (line: string) =
    let regex = Regex("Vampires: (?<vs>\d+), Zombies: (?<zs>\d+), Witches: (?<ws>\d+), Houses: (?<hs>\d+)")
    let m = regex.Match line
    let houses = Int32.Parse(m.Groups.["hs"].Value)
    let kids = {
        vampires = Int32.Parse(m.Groups.["vs"].Value)
        zombies  = Int32.Parse(m.Groups.["zs"].Value)
        witches  = Int32.Parse(m.Groups.["ws"].Value)
        }
    kids, houses

let calculateAvg (kids_dist: CandyDist) (kids: DressedKids) (houses: int) =
    let total_kids  = kids.zombies + kids.witches + kids.vampires
    let total_candy = kids.vampires * kids_dist.vampire_candy +
                      kids.zombies  * kids_dist.zombie_candy  +
                      kids.witches  * kids_dist.witch_candy
    total_candy * houses / total_kids


[<EntryPoint>]
let main args =
    let kids_dist = {vampire_candy = 3; zombie_candy = 4; witch_candy = 5}
    File.ReadLines(args.[0])
    |> Seq.map parseLine
    |> Seq.map (fun (kids, houses) -> calculateAvg kids_dist kids houses)
    |> Seq.iter (printfn "%d")
    0
