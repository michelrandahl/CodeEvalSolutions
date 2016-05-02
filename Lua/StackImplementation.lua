function push(stack, el)
  table.insert(stack, el)
end

function pop(stack)
  return table.remove(stack)
end

test = "1 2 3 4"
stack = {}
test:gsub("([^ ]+)", function(c) stack[#stack+1] = c end)
result = {}
while true do
  push(result, pop(stack))
  if #stack == 0 then break end
  pop(stack)
  if #stack == 0 then break end
end


for line in io.lines(arg[1]) do
  local stack = {}
  line:gsub("([^ ]+)", function(c) stack[#stack+1] = c end)
  local result = {}
  while true do
    push(result, pop(stack))
    if #stack == 0 then break end
    pop(stack)
    if #stack == 0 then break end
  end

  io.write(table.concat(result, " ") .. "\n")
end
