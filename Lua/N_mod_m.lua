-- a % b == a - math.floor(a/b)*b
function mymod(n,m)
  return n - math.floor(n/m)*m
end

print(mymod(20,6))
line = "20,6"
local args = {}
line:gsub("[^,]+", function(x) args[#args + 1] = tonumber(x) end)
print(table.concat(args, " "))

for line in io.lines(arg[1]) do
  local args = {}
  line:gsub("[^,]+", function(x) args[#args + 1] = tonumber(x) end)
  print(mymod(args[1], args[2]))
end
