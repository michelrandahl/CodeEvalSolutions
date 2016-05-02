function primeNumbers(N)
  local n = 1
  local primes = {}
  repeat
    n = n + 1
    if n == 2 or n == 3 then
      primes[#primes + 1] = n
    elseif n % 2 == 0 or n % 3 == 0 then
      goto continue
    else
      local i = 5
      local is_prime = true
      while i*i <= n do
        if n % i == 0 or n % (i+2) == 0 then
          is_prime = false
          break
        end
        i = i + 1
      end
      if is_prime then
        primes[#primes + 1] = n
      end
    end
    ::continue::
  until n >= N
  return primes
end


for line in io.lines(arg[1]) do
  local N = tonumber(line)
  io.write(table.concat(primeNumbers(N), ",") .. "\n")
end
