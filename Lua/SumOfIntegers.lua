function permutations(xs)
  local result = {}
  local N = #xs
  for to_take = 1,N do
    for to_skip = 0,N-1 do

      if to_take + to_skip <= N then
        local permutation = {}
        for i = 1+to_skip, to_skip + to_take do
          permutation[#permutation + 1] = xs[i]
        end
        result[#result + 1] = permutation
      end

    end
  end
  return result
end

function sum(xs)
  local s = 0
  for _,x in ipairs(xs) do
    s = s + x
  end
  return s
end

for line in io.lines(arg[1]) do
  local numbers = {}
  line:gsub("([^,]+)", function(c) numbers[#numbers+1] = tonumber(c) end)

  local perms = permutations(numbers)
  local max = sum(perms[1])
  for i = 2,#perms do
      local s = sum(perms[i])
      if s > max then
      max = s
      end
  end
  print(max)

end
