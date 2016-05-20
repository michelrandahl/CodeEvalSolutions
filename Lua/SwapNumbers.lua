function swapNumbersOnWord(text)
  local word = string.match(text, "%a+")
  local numbers = {}
  text:gsub("%d+", function(d) table.insert(numbers, d) end)
  local n1, n2 = table.unpack(numbers)
  return (n2 .. word .. n1)
end

function swapNumbersOntext(text)
  local words = {}
  for word in string.gmatch(text, "(%w+)") do
    table.insert(words, swapNumbersOnWord(word))
  end
  return table.concat(words, " ")
end

for line in io.lines(arg[1]) do
  print(
    swapNumbersOntext(line)
  )
end
