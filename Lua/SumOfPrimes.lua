function primeNumbers()
  local n = 1
  return function()
    while true do
      n = n + 1
      if n == 2 or n == 3 then
        return n
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
          return n
        end
      end
      ::continue::
    end
  end
end

counter = 1
sum = 0
for prime in primeNumbers() do
  if counter > 1000 then
    break
  end
  counter = counter + 1
  sum = sum + prime
end
io.write(sum .. "\n")
