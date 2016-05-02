function fib(n)
  function loop(n1, n2, count)
    if count == n then return n2
    else
      return loop(n2, n1+n2, count+1)
    end
  end

  if n == 0 then
    return 0
  else
    return loop(0, 1, 1)
  end
end

print(fib(0))
print(fib(1))
print(fib(2))
print(fib(3))
print(fib(4))
print(fib(5))

--[[
for line in io.lines(arg[1]) do
    io.write(fib(tonumber(line)) .. '\n')
end
--]]
