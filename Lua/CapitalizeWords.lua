function capitalize(line)
  local result = {}
  for w in string.gmatch(line, "%g+") do
    local head = string.sub(w, 1, 1)
    local rest = string.sub(w, 2)
    table.insert(result, string.upper(head) .. rest)
  end
  return table.concat(result, " ")
end

for line in io.lines(arg[1]) do
  print(
    capitalize(line)
  )
end
