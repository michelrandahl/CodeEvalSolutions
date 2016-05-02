defmodule ReverseWords do
  def reverseWords(words) when is_binary(words) do
    words
    |> String.split(" ", trim: true)
    |> reverseWords
  end
  def reverseWords(words) do
    words
    |> Enum.reverse
    |> Enum.join(" ")
  end
end
