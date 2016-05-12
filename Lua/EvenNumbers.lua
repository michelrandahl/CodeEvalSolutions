for line in io.lines(arg[1]) do
  local num = tonumber(line)
  if math.fmod(num, 2) == 0 then
    print(1)
  else
    print(0)
  end
end
