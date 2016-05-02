defmodule OddNumbers do
  def oddNumbers do
    Enum.filter 1..99, fn n -> rem(n, 2) != 0 end
  end
end
