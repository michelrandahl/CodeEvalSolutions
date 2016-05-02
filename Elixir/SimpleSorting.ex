defmodule SimpleSorting do
  def simpleSorting(s) when is_binary(s) do
    String.split(s, " ", trim: true)
    |> Enum.map(&(String.to_float &1))
    |> Enum.sort
    |> Enum.map(&(Float.to_string &1, [decimals: 3]))
    |> Enum.join(" ")
  end
end
