function point(x, y)
  return {x = x, y = y}
end

function euclidDistance(p1, p2)
  return math.sqrt(
    (p1.x - p2.x)^2 +
      (p1.y - p2.y)^2
  )
end

function parseLine(line)
  local points = {}
  for x,y in string.gmatch(line, "%((%g+), (%g+)%)") do
    points[#points + 1] = point(tonumber(x), tonumber(y))
  end
  return table.unpack(points)
end

for line in io.lines(arg[1]) do
  local p1, p2 = parseLine(line)
  local result = euclidDistance(p1, p2)
  io.write(result .. "\n")
end
