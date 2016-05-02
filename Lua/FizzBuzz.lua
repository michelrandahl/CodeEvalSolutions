function fizzBuzz(x, y, N)
  local result = {}
  for n = 1,N do
    if n % x == 0 and n % y == 0 then
      result[#result + 1] = "FB"
    elseif n % x == 0 then
      result[#result + 1] = "F"
    elseif n % y == 0 then
      result[#result + 1] = "B"
    else
      result[#result + 1] = tostring(n)
    end
  end
  return table.concat(result, " ")
end


for line in io.lines(arg[1]) do
  local fields = {}
  line:gsub("([^ ]+)", function(f) fields[#fields+1] = tonumber(f) end)
  local x, y, N = fields[1], fields[2], fields[3]

  io.write(fizzBuzz(x, y, N) .. "\n")
end
