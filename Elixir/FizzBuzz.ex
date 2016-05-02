defmodule FizzBuzz do
  defp fizzbuzz(x, y, n)
    when rem(n,x) == 0 and rem(n,y) == 0 do
    "FB"
  end
  defp fizzbuzz(x, y, n)
    when rem(n,x) == 0, do: "F"
  defp fizzbuzz(x, y, n)
    when rem(n,y) == 0, do: "B"
  defp fizzbuzz(x, y, n), do: Integer.to_string n

  def fizzbuzz(s) when is_binary(s) do
    [x, y, n] =
      String.split(s, " ", trim: true)
      |> Enum.map &(String.to_integer &1)
    1..n
    |> Enum.map(&(fizzbuzz x, y, &1))
    |> Enum.join(" ")
  end
end
