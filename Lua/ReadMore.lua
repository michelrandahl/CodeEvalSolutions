function readMore(line)
  if #line <= 55 then
    return line
  else
    local xs = {}
    local xs_no_spaces = {}
    local skip = true

    for i = 0, 39 do
      local string_index1 = i + 1
      xs_no_spaces[string_index1] = line:sub(string_index1, string_index1)

      local string_index2 = 40 - i
      local char = line:sub(string_index2, string_index2)


      if not(skip) then
        xs[#xs + 1] = char
      end

      if char == " " then
        skip = false
      end
    end

    if skip then
      return table.concat(xs_no_spaces, "") ..  "... <Read More>"
    else
      return table.concat(xs, ""):reverse() .. "... <Read More>"
    end
  end
end

test = "Truck off'n your outside turn round that they wondered what you would have."
print(readMore(test))

for line in io.lines(arg[1]) do
  print(readMore(line))
end
