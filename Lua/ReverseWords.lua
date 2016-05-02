function reverseWords(words)
  local list = {}
  for word in string.gmatch(words, "%S+") do
    list[#list + 1] = word
  end
  local result = list[#list]
  for i = #list-1,1,-1 do
    result = string.format("%s %s", result, list[i])
  end
  print(result)
end

for line in io.lines(arg[1]) do
  io.write(reverseWords(line))
end

