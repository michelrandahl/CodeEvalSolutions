defmodule LongestWord do
  defp longestWord([x1|[x2|xs]]) do
    if String.length(x2) > String.length(x1) do
      longestWord [x2|xs]
    else
      longestWord [x1|xs]
    end
  end
  defp longestWord([x]), do: x

  def eval(s) when is_binary(s) do
    String.split(s, " ", trim: true)
    |> longestWord
  end
end
