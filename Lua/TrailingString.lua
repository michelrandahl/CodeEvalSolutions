function parseLine(line)
  local result = {}
  line:gsub("[^,]+", function(x) table.insert(result, x) end)
  return table.unpack(result)
end

for line in io.lines(arg[1]) do
  local text, match_end = parseLine(line)

  if string.match(text, match_end .. "$") then
    print(1)
  else print(0)
  end
end
