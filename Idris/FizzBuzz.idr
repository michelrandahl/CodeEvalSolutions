-- idea: insert filename string directly
-- convert to js and replace with
-- process.argv[1]
module Main

import System
import Data.Vect
import Data.String

record Inputs where
  constructor MkInputs
  input_x, input_y, input_n : Int

readLines : (file : File) -> IO (List (Maybe Inputs))
readLines file = do
    eof <- fEOF file
    if eof then
      pure []
    else do
      Right line <- fGetLine file
      let x = toInputs (words line)
      xs <- readLines file
      pure(x :: xs)
  where
    toInputs : (xs: List String) -> Maybe Inputs
    toInputs xs =
      case the (List Int) (mapMaybe parsePositive xs) of
           [x',y',n'] => Just (MkInputs x' y' n')
           _ => Nothing

fizzBuzz : Inputs -> List String
fizzBuzz inputs =
  let
    x = input_x inputs
    y = input_y inputs
    n = toNat $ input_n inputs
  in
    --loop x y n []
    ?dsfdsf
  where
    loop : (x: Int) -> (y: Int) -> (n: Nat) -> (xs: List String) -> List String
    loop _ _ Z xs = xs
    loop x y (S k) xs =
      let
        n' = toIntNat (S k)
        loop' = loop x y k
      in
      case (mod n' x, mod n' y) of
           (0, 0) => loop' ("FB" :: xs)
           (0, _) => loop' ("F" :: xs)
           (_, 0) => loop' ("B" :: xs)
           (_, _) => loop' ((show n') :: xs)

printAll : List String -> IO ()
printAll [] = pure ()
printAll (x :: xs) = do
  putStrLn x
  printAll xs

main : IO ()
main = do
  Right f <- openFile "FizzBuzz.test" Read
  xs <- readLines f
  printAll $ map unwords $ map fizzBuzz $ mapMaybe id xs

