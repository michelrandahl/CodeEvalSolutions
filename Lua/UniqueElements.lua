line = "1,1,1,2,2,3,3,4,4"
numbers = {}
line:gsub("([^,]+)", function(x) numbers[#numbers + 1] = x end)
numbers_set = {}
for i = 1,#numbers do
  numbers_set[numbers[i]] = true
end
result = {}
for k,v in pairs(numbers_set) do
  result[#result + 1] = k
end
table.sort(result)
print(table.concat(result, ","))


for line in io.lines(arg[1]) do
  local numbers = {}
  line:gsub("([^,]+)", function(x) numbers[#numbers + 1] = x end)
  local numbers_set = {}
  for i = 1,#numbers do
    numbers_set[numbers[i]] = true
  end
  local result = {}
  for k,v in pairs(numbers_set) do
    result[#result + 1] = tonumber(k)
  end
  table.sort(result)

  io.write(table.concat(result, ",") .. "\n")
end
