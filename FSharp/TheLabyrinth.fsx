open System
open System.IO

type MazeElement = Wall | Path

let input = """
************************* *************************
*                                   * *           *
* * *** *** ******************* ***** * * * * * ***
* * *   * *   *   * * *                 * * * *   *
***** * * *** * *** * * *** *** * ***** *** *******
*     * *   * *     *   * * *   *     * * *       *
*** ******* * ***** *** * * ******* * *** * *** * *
* *     *     *   *     *     *     * *       * * *
* * *********** * ********* * ******* * *** * *****
*     * *   * * *     *     * *   *   * *   *     *
* ***** * *** * ***** *** *** * * * ******* ***** *
* *     *   * * *       * * *   * * * *   *     * *
* * ***** *** *** *** *** * ***** *** *** ***** ***
*     *   * * *     * *       * *       * *     * *
* * ***** * * * *** * *** ***** *** ***** *** * * *
* * *           *   * *   *     *     *     * *   *
* ******* ******* * *** ******* *** * * ********* *
*   *       *     * *   *         * * * *     *   *
*** * * ***** * ***** ******* ******* * * * * * ***
*     *   *   *         *       * *   * * * * *   *
*** * *** * *** ***** ******* * * * *** *** * *** *
* * * * * * * *     * * *     *       *   * * * * *
* * *** * * * *** *** * * ********* ***** * * * * *
* * *   * * *     *   * *   *     *   *     * * * *
* * * *** ******* ***** * ******* *** * *** *** * *
* * *     *   *   *     * *     * * * *   *   * * *
* ***** * * * *** * ***** ***** * * * ***** * * * *
* *     * * * *     * *     *           * * *   * *
* ***** * *** * ***** *********** ******* * * * * *
*     * * * *             *   *     * * *   * * * *
* * * *** * *** * ***** ***** ******* * *** * * * *
* * *   * * *   *     * *             *     * * * *
* ***** * * *********** ******* *** * ******* * * *
* *     *   *   *     * *   *   * * *       * *   *
* * * ********* * ***** * *** *** *** * ***** * ***
* * *       *           *   * * *   * *   *   *   *
* ******* ***** ******* * *** * * *** *** * *******
*   *   *   *   *   *     *         * * * * * * * *
* ***** * *** ***** * ******* * ***** * *** * * * *
*     *           *     *     * * *   *   *     * *
*** *** ********************* *** *** *** *** * * *
*   *   *     *               * * *   *       *   *
*** *** * ***** * ******* *** * * *** * *** ***** *
*       *       *   *   * * *   *     *   * *   * *
*** ***** ***** *** *** *** ***** * * *** *** * * *
*       *   *   * * *       *   * * *   * *   *   *
*** *** * ***** * ***** *** *** *** *** ******* ***
*   *     *   *   *     * * * *     * * *     *   *
* ***** *** ***** ******* * * *** *** * *** ***** *
*   *                 *           *         *     *
************************* *************************
"""

let extracted_lines: string list =
    input.Split '\n'
    |> Seq.filter ((<>)"")
    |> Seq.map (fun s -> s.Trim())
    |> List.ofSeq

let parseElement = function
| '*' -> Some(Wall)
| ' ' -> Some(Path)
| _   -> None

let raiseInvalidElement row col =
    (row,col)
    ||> (sprintf "(%d,%d) invalid element")
    |> Exception
    |> raise


let parseLineWithEntrance (line: string) (row: int) =
    let rec loop (line: char list) (col: int) (parsed: ((int*int)*MazeElement) list) (entrance: (int*int) option) =
        match line with
        | []      -> parsed, entrance
        | c::line ->
            let parsed_element = parseElement c
            match parsed_element with
            | None -> raiseInvalidElement row col
            | Some(Wall) -> 
                let entry = (row,col),Wall
                loop line (col+1) (entry::parsed) entrance
            | Some(Path) ->
                let entry = (row,col),Path
                loop line (col+1) (entry::parsed) (Some(row,col))
    loop (List.ofSeq line) 0 [] None
            
let parseLine (line: string) (row: int) =
    line
    |> Seq.mapi
        (fun col c ->
            let parsed_element = parseElement c
            match parsed_element with
            | None -> raiseInvalidElement row col
            | Some(el) -> (row,col),el)
    |> List.ofSeq

let parseMaze (lines: string list) =
    let rec loop (lines: string list) (row: int) (parsed_maze: ((int*int)*MazeElement) list list) (start: (int*int) option) (goal: (int*int) option) = 
        match lines with
        | []          -> parsed_maze, start, goal
        | [last_line] ->
            let parsed_line, goal' = parseLineWithEntrance last_line row 
            (parsed_line :: parsed_maze), start, goal'
        | line::lines ->
            if row = 0 then
                let parsed_line, start' = parseLineWithEntrance line row
                loop lines (row+1) (parsed_line :: parsed_maze) start' goal
            else
                let parsed_line = parseLine line row
                loop lines (row+1) (parsed_line :: parsed_maze) start goal
    loop lines 0 [] None None

type AstarNode = {
    fScore: int
    gScore: int
    cameFrom: (int*int) option
}

let manhattanDist (a: int*int) (b: int*int) =
    Math.Abs(fst a - fst b) + Math.Abs(snd a - snd b)

let aStar (maze: Map<int*int, MazeElement>) (start: int*int) (goal: int*int) =
    let heuristicCost = manhattanDist
    let neighbors (x: int*int) =
        seq {
            yield fst x-1, snd x
            yield fst x, snd x-1
            yield fst x, snd x+1
            yield fst x+1, snd x
        } |> Seq.filter
            (fun x ->
                match Map.tryFind x maze with
                | Some(Path) -> true
                | _          -> false)

    let rec loop (closedset: Set<int*int>)
                 (openset: Set<int*int>)
                 (nodes: Map<int*int, AstarNode>) =
        match openset with
        | s when Set.isEmpty s -> Exception("no path found") |> raise
        | _ ->
            let current = openset
                          |> Seq.sortBy (fun x -> nodes.[x].fScore)
                          |> Seq.head
            if current = goal then
                printfn "hurray!"
                nodes
            else
                let closedset' = Set.add current closedset
                let neighbors' = neighbors current
                                 |> Seq.filter (fun n -> not <| Set.contains n closedset)
                let tentative_gScore = nodes.[current].gScore + 1
                let new_neighbors = neighbors' |> Seq.filter (fun n -> not <| Set.contains n openset)
                let openset' = 
                    openset |> Set.remove current
                    |> Set.union (Set.ofSeq new_neighbors)
                let neighbors_to_update =
                    neighbors' |> Seq.filter (fun n -> Set.contains n openset &&
                                                       tentative_gScore < nodes.[n].gScore)
                let nodes' =
                    [new_neighbors; neighbors_to_update]
                    |> Seq.concat
                    |> Seq.fold (fun m n -> 
                        let node = {
                            gScore = tentative_gScore
                            fScore = tentative_gScore + (heuristicCost n goal)
                            cameFrom = Some(current) }
                        Map.add n node m) nodes
                loop closedset' openset' nodes'

    let closedset, openset = Set.empty<int*int>, Set.ofList [start]
    let node = {
        cameFrom = None
        gScore = 0
        fScore = heuristicCost start goal }
    let nodes = Map.ofList [start,node]
    loop closedset openset nodes

let markPath (maze: Map<int*int, MazeElement>) (nodes: Map<int*int, AstarNode>) (goal: int*int) =
    let maze' =
        maze
        |> Map.map (fun k v -> match v with
                               | Wall -> '*'
                               | Path -> ' ')
    let rec loop (maze: Map<int*int, char>) (current: int*int) =
        let maze' = Map.add current '+' maze
        match nodes.[current].cameFrom with
        | None -> maze'
        | Some(from) -> loop maze' from
    loop maze' goal

let drawPath (maze: Map<int*int, char>) =
    let cols = maze |> Map.toSeq |> Seq.maxBy (fun entry -> snd (fst entry)) |> fst |> snd
    let rows = maze |> Map.toSeq |> Seq.maxBy (fun entry -> fst (fst entry)) |> fst |> fst
    seq {
        for row in 0..rows do
            yield [for col in 0..cols -> maze.[row,col]]
    }


let parsed_maze, start, goal = parseMaze extracted_lines
match start,goal with
| Some(start'), Some(goal') ->
    let parsed_maze' =
        parsed_maze
        |> Seq.concat
        |> Map.ofSeq
    let nodes = aStar parsed_maze' start' goal'
    markPath parsed_maze' nodes goal'
    |> drawPath
    |> Seq.map (Seq.map string)
    |> Seq.map (String.concat "")
    |> String.concat "\n"
| _ -> Exception("no start or goal!") |> raise


[<EntryPoint>]
let main(args) =    
    let lines = File.ReadLines(args.[0])
    let extracted_lines: string list =
        lines
        |> Seq.filter ((<>)"")
        |> Seq.map (fun l -> l.Trim())
        |> List.ofSeq
    let parsed_maze, start, goal = parseMaze extracted_lines

    match start,goal with
    | Some(start'), Some(goal') ->
        let parsed_maze' =
            parsed_maze
            |> Seq.concat
            |> Map.ofSeq
        let nodes = aStar parsed_maze' start' goal'
        markPath parsed_maze' nodes goal'
        |> drawPath
        |> Seq.map (Seq.map string)
        |> Seq.map (String.concat "")
        |> Seq.iter (printfn "%s")
    | _ -> Exception("no start or goal!") |> raise
    0
