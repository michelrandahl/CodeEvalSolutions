lines = {}
for line in io.lines(arg[1]) do
  lines[#lines + 1] = line
end
N = table.remove(lines, 1)
table.sort(lines, function(a, b) return #a > #b end)
for i = 1,N do
  print(lines[i])
end

