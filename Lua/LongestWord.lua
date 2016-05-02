function longestWord(words)
  local list = {}
  local longestWord = ""
  for word in string.gmatch(words, "%S+") do
    if #word > #longestWord then
      longestWord = word
    end
  end
  return longestWord
end

for line in io.lines(arg[1]) do
  io.write(longestWord(line) .. "\n")
end
