open System
open System.IO
open System.Text.RegularExpressions

type Coordinate = {
    x: float
    y: float
}
type Position = {
    coordinate: Coordinate
    id: int
}

let rnd = Random()
let random() = rnd.NextDouble()

//shuffles an array
let Shuffle (xs: 'a []) = 
    let arr = Array.copy xs
    let max = (arr.Length - 1)
    let randomSwap (arr: 'a []) i =
        let pos = rnd.Next(max)
        let tmp = arr.[pos]
        arr.[pos] <- arr.[i]
        arr.[i] <- tmp
        arr
    [|0..max|] 
    |> Array.fold randomSwap arr


//calculates the diff between two lists
let not_in (ps': 'a seq) (ps: 'a seq) =
    ps |> Seq.filter (fun p -> not(Seq.exists (fun p' -> p' = p) ps'))


//euclidian dist between two points in a plane
let Distance (g1: Position) (g2: Position) =
    Math.Sqrt((g1.coordinate.x - g2.coordinate.x)**2.0 + (g1.coordinate.y - g2.coordinate.y)**2.0)


//score a list of cities for TSP
let Score population_member = 
    let rec loop = function
        | x::[],      score -> score
        | x1::x2::xs, score -> 
            let score' = Distance x1 x2
            loop (x2::xs, score + score')
        | _,score -> score
    loop(List.ofArray population_member, 0.0)


//check for intersection between two line segments
let intersection (line1: Position*Position) (line2: Position*Position) =
    let cmp = (fst line2).coordinate.x - (fst line1).coordinate.x, (fst line2).coordinate.y - (fst line1).coordinate.y
    let r = (snd line1).coordinate.x - (fst line1).coordinate.x, (snd line1).coordinate.y - (fst line1).coordinate.y
    let s = (snd line2).coordinate.x - (fst line2).coordinate.x, (snd line2).coordinate.y - (fst line2).coordinate.y

    let cmpxr = fst cmp * snd r - snd cmp * fst r
    let cmpxs = fst cmp * snd s - snd cmp * fst s
    let rxs = fst r * snd s - snd r * fst s

    if rxs < 0.001 then
        false
    else
        let rxsr = 1.0 / rxs
        let t = cmpxs * rxsr
        let u = cmpxr * rxsr
        (t >= 0.001) && (t <= 1.0) && (u >= 0.001) && (u <= 1.0)


//count number of intersections in a given TSP plan
let intersection_count (cities: Position []) =
    let connected_cities = cities |> Seq.windowed 2
    seq {
        for con in connected_cities do
            for con' in connected_cities do
                if con <> con' && con.[1] <> con'.[0] && con'.[1] <> con.[0] then
                    let intersects = intersection (con.[0],con.[1]) (con'.[0],con'.[1])
                    if intersects then
                        yield set [(con.[0],con.[1]); (con'.[0],con'.[1])]
    } 
    |> Set.ofSeq
    |> Seq.length


//function to swap two random indexes
let rswap_indexes (cities: Position []) = 
    let swap_index1 = random() * (float cities.Length) |> int
    let swap_index2 = 
        random() * (float cities.Length)
        |> int
        |> fun x -> 
            if x = swap_index1 then 
                if x > 0 then x - 1
                else x + 1
            else x

    cities |> Seq.mapi (fun i v ->
        if i = swap_index1 then cities.[swap_index2]
        else if i = swap_index2 then cities.[swap_index1]
        else v)
    |> Array.ofSeq

type Configuration = {
    StartTemp: float
    CoolingRate: float
}

//simulated annealing takes a configuration and a list of cities as arguments
//and attempts at finding an optimal permutation
let SimulatedAnnealing (config: Configuration) (cities: Position []) =
    let cities_count = Seq.length cities

    let rec loop prev_score cities temp = seq {
        let candidate_cities' =
            (Array.get cities 0) :: (
             cities
             |> Array.skip 1
             |> Array.copy
             |> rswap_indexes
             |> List.ofArray)
            |> Array.ofList

        let score = Score candidate_cities'
        //calculating the probability of accepting the given solution
        let accept_prob = 
            if score > prev_score then
                let delta_h = prev_score - score
                Math.Exp(delta_h / temp)
            else 1.0

        //decrease the temperature
        let temp' = temp * (1.0 - config.CoolingRate)

        if random() < accept_prob then
            yield score,candidate_cities'
            yield! loop score candidate_cities' temp'
        else 
            yield prev_score,cities
            yield! loop prev_score cities temp'
    }

    let score = Score cities
    loop score cities config.StartTemp



let input = 
    """
    1 | CodeEval 1355 Market St, SF (37.7768016, -122.4169151)
    2 | Yelp 706 Mission St, SF (37.7860105, -122.4025377)
    3 | Square 110 5th St, SF (37.7821494, -122.4058960)
    4 | Airbnb 99 Rhode Island St, SF (37.7689269, -122.4029053)
    5 | Dropbox 185 Berry St, SF (37.7768800, -122.3911496)
    6 | Zynga 699 8th St, SF (37.7706628, -122.4040139)
    7 | Mashery 717 Market St, SF (37.7870361, -122.4039444) 
    8 | Flurry 3060 3rd St, SF (37.7507903, -122.3877184) 
    9 | New Relic 188 Spear St, SF (37.7914417, -122.3927229) 
    10 | Glassdoor 1 Harbor Drive, Sausalito (37.8672841, -122.5010216) 
    """

let (|Integer|_|) (str: string) =
   let mutable intvalue = 0
   if System.Int32.TryParse(str, &intvalue) then Some(intvalue)
   else None

let (|Float|_|) (str: string) =
   let mutable floatvalue = 0.0
   if System.Double.TryParse(str, &floatvalue) then Some(floatvalue)
   else None

let ParseLine (line: string) =
    let regex = Regex "^(\d{1,2}) \|.+\((\d+.\d+), (-?\d+.\d+)\)$" 
    let m = regex.Match line
    if m.Success then
        match List.tail [for x in m.Groups -> x.Value] with
        | [Integer idx; Float x; Float y] ->
            Some {coordinate={x=x; y=y}; id=idx}
        | _ -> None
    else None

let cities =
    input.Split '\n'
    |> Seq.map (fun line -> line.Trim())
    |> Seq.filter ((<>)"")
    |> Seq.map ParseLine
    |> Seq.map (Option.toList)
    |> Seq.concat
    |> List.ofSeq

let solution' =
    cities
    |> Array.ofList
    |> SimulatedAnnealing {StartTemp=50000.0; CoolingRate=0.001} 
    |> Seq.take 25000

let best_sol = solution' 
               |> Seq.minBy fst 
let scores = solution' 
             |> Seq.map fst 
             |> List.ofSeq 
let solution = snd best_sol 

fst best_sol,
solution
|> Seq.iter (fun pos -> printfn "%d" pos.id)

