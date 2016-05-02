function sumDigits(input)
  sum = 0
  for d in string.gmatch(input, "%d") do
    sum = sum + d
  end
  return sum
end

digits = "234521"
print(sumDigits(digits))

for line in io.lines(arg[1]) do
  io.write(sumDigits(line) .. "\n")
end
