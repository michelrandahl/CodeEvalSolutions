function string:split(sep, convert_fun)
  local sep, fields, f = sep, {}, convert_fun or identity
  local pattern = string.format("([^%s]+)", sep)
  self:gsub(pattern, function(c) fields[#fields+1] = f(c) end)
  return fields
end

function identity(x)
  return x
end

function sum(xs)
  local s = 0
  for _,x in ipairs(xs) do
    s = s + x
  end
  return s
end

function permute(xs)
  local perms = {}
  for i = 1,#xs do
    for j = i+1,#xs do
      perms[#perms + 1] = {xs[i], xs[j]}
    end
  end
  return perms
end

for line in io.lines(arg[1]) do
  local test_values = line:split(";")
  local expected_sum = tonumber(test_values[2])
  local numbers = test_values[1]:split(",", tonumber)

  local perms = permute(numbers)
  local valid_pairs = {}
  for _,p in ipairs(perms) do
    if sum(p) == expected_sum then
      valid_pairs[#valid_pairs + 1] = p
    end
  end

  if #valid_pairs > 0 then
    local to_print = {}
    for _,pair in ipairs(valid_pairs) do
      to_print[#to_print + 1] = table.concat(pair, ",")
    end
    print(table.concat(to_print, ";"))
  else
    print("NULL")
  end

end
