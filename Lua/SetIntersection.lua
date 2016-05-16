function parseInput(input)
  local xss = {}
  local lists = {}
  input:gsub("[^;]+", function(s) table.insert(lists, s) end)
  function parseList(l_string)
    local xs = {}
    l_string:gsub(
      "[^,]+",
      function(x) table.insert(xs, tonumber(x)) end
    )
    return xs
  end
  xss[1] = parseList(lists[1])
  xss[2] = parseList(lists[2])
  return xss
end

function intersect(xs, ys)
  local result = {}

  function loop()
    if #xs > 0 or #ys > 0 then
      local not_empty = #xs > 0 and #ys > 0
      if (not_empty and xs[1] < ys[1]) or #ys == 0 then
        local x = table.remove(xs, 1)
      elseif not_empty and xs[1] > ys[1] or #xs == 0 then
        local y = table.remove(ys, 1)
      else
        table.remove(xs, 1)
        table.insert(result, table.remove(ys, 1))
      end
      return loop()
    end
  end

  loop()
  return result
end

for line in io.lines(arg[1]) do
  local xss = parseInput(line)
  local res = intersect(xss[1], xss[2])
  if #res > 0 then
    print(table.concat(res, ","))
  else
    io.write("\n")
  end
end
