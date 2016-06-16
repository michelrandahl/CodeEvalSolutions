function mthLast(input)
  local arr = {}
  input:gsub("[^ ]+", function(x) table.insert(arr, x) end)
  local n = tonumber(arr[#arr])
  print(n)
  if n <= #arr - 1 then
    local i = #arr - n
    return arr[i]
  else
    return ""
  end
end

for line in io.lines(arg[1]) do
  local res = mthLast(line)
  if res ~= "" then
    print(line)
    print(res)
  end
end
