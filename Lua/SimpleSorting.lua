function simpleSort(input)
  numbers = {}
  for n in string.gmatch(input, "%-?%d+%p%d+") do
    numbers[#numbers + 1] = tonumber(n)
  end
  table.sort(numbers)
  for i = 1,#numbers do
    numbers[i] = string.format("%.3f", numbers[i])
  end
  return table.concat(numbers, " ")
end

for line in io.lines(arg[1]) do
  io.write(simpleSort(line) .. "\n")
end
