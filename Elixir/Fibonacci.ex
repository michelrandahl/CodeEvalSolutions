defmodule Fibonacci do
  defp fib(n1, n2, count, count), do: n2
  defp fib(n1, n2, count, n) do
    fib(n2, n1+n2, count+1, n)
  end

  def fib(0), do: 0
  def fib(n) when is_number(n) do
    fib(0, 1, 1, n)
  end
  def fib(n) when is_binary(n) do
    String.to_integer(n)
    |> fib
  end
end
