defmodule SumOfDigits do
  def sumOfDigits(s) when is_binary(s) do
    String.split(s, "", trim: true)
    |> Enum.filter(&(&1 != ""))
    |> Enum.map(&(String.to_integer &1))
    |> Enum.sum
  end
end
