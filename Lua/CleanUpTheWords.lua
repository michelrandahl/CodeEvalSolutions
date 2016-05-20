function cleanText(messy_text)
  local result = {}
  messy_text:gsub("%a+", function(word) table.insert(result, word) end)
  return table.concat(result, " ")
end

for line in io.lines(arg[1]) do
  local cleaned = cleanText(line)
  print(string.lower(cleaned))
end
