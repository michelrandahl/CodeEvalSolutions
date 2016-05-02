defmodule SetIntersection do
  def setIntersection(s) when is_binary(s) do
    String.split(s, ";", trim: true)
    |> Enum.map(&(String.split &1, ",", trim: true))
    |> Enum.map(fn xs -> (Enum.map xs, &(String.to_integer &1)) end)
    |> Enum.map(&(MapSet.new &1))
    |> Enum.reduce(&(MapSet.intersection &1, &2))
    |> Enum.sort
    |> Enum.join(",")
  end
end
