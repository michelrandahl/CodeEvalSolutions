function parseInput(input)
  local xss = {}
  local lists = {}
  input:gsub("[^|]+", function(s) table.insert(lists, s) end)
  function parseList(l_string)
    local xs = {}
    l_string:gsub("[^ ]+", function(x) table.insert(xs, x) end)
    return xs
  end
  xss[1] = parseList(lists[1])
  xss[2] = parseList(lists[2])
  return xss
end

function multLists(xss, ys)
  local result = {}
  function loop(xss)
    if #xss[1] > 0 then
      local x = table.remove(xss[1], 1)
      local y = table.remove(xss[2], 1)
      table.insert(result, x*y)
      return loop(xss)
    end
  end
  loop(xss)
  return result
end

test = "9 0 6 | 15 14 9"
xss = parseInput(test)
res = multLists(xss)


for line in io.lines(arg[1]) do
  local xss = parseInput(line)
  local res = multLists(xss)
  print(table.concat(res, " "))
end
