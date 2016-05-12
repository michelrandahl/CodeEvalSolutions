module Main


printOddNumbers : (n: Int) -> (n_max: Int) -> IO ()
printOddNumbers n n_max =
  if n <= n_max then do
    case mod n 2 of
      0 => pure ()
      _ => putStrLn(show n)
    printOddNumbers (n+1) n_max
  else
    pure ()


main : IO ()
main = do
  printOddNumbers 1 99


