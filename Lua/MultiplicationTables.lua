mult_table = {}
for x = 1,12 do
  local row = {}
  for y = 1,12 do
    row[#row + 1] = string.format("% 4d", x*y)
  end
  mult_table[#mult_table + 1] = table.concat(row, "")
end

print(
  table.concat(mult_table, "\n")
)
