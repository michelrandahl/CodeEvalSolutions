function string:split(sep)
    local sep, fields = sep or ":", {}
    local pattern = string.format("([^%s]+)", sep)
    self:gsub(pattern, function(c) fields[#fields+1] = c end)
    return fields
end

function parseLine(line)
  local splitted_line = line:split(";")
  local text = splitted_line[1]:split(" ")
  local order = splitted_line[2]:split(" ")
  return text, order
end

function calcFullOrder(n, order)
  local numbers = {}
  local full_order = {}
  for i = 1,#order do full_order[i] = order[i] end
  for i = 1,n do numbers[#numbers + 1] = true end
  for k,v in pairs(order) do
    numbers[tonumber(v)] = false
  end
  for k,v in pairs(numbers) do
    if v then
      full_order[#full_order + 1] = k
    end
  end
  return full_order
end

function reorder(order, text)
  local result = {}
  for k,v in pairs(order) do
    result[tonumber(v)] = text[k]
  end
  return result
end

test = "1958 substantially and FLOW-MATIC publicly became in complete early compiler The 1959 in was available;9 12 10 2 5 4 14 13 8 3 1 15 7 11"
text, order = parseLine(test)
full_order = calcFullOrder(#text, order)
reordered = reorder(full_order, text)
for k,v in pairs(reordered) do
  print(type(k))
  print(k, v)
end
result = table.concat(reordered, " ")
print(result)
print(table.concat({"a", "b", "c"}, " "))


for line in io.lines(arg[1]) do
  local text, order = parseLine(line)
  local full_order = calcFullOrder(#text, order)
  local reordered = reorder(full_order, text)
  local result = table.concat(reordered, " ")

  io.write(result .. "\n")
end
