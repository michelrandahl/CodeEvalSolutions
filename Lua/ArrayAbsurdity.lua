test = "5;0,1,2,3,0"

function tableFromInput(input)
  local len_array = {}
  input:gsub(
    "[^;]+",
    function(s) table.insert(len_array, s) end
  )
  local xs = {}
  len_array[2]:gsub(
    "[^,]+",
    function(x) table.insert(xs, x) end
  )
  return xs
end

function findDuplicate(arr)
  table.sort(arr)

  function loop(arr)
    if #arr >= 2 then
      local x = table.remove(arr, 1)
      if x == arr[1] then
        return x
      else
        return loop(arr)
      end
    else
      print("err: no duplicates!")
    end
  end

  return loop(arr)
end

x = findDuplicate(tableFromInput(test))
print(x)


for line in io.lines(arg[1]) do
  print(
    findDuplicate(tableFromInput(line))
  )
end
