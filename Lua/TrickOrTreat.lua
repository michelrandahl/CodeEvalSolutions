function parseLine(line)
  for v,z,w,h in string.gmatch(
    line,
    "Vampires: (%d+), Zombies: (%d+), Witches: (%d+), Houses: (%d+)") do
    return kids_count(v, z, w), h
  end
end

candy_distribution = {
  vampires = 3,
  zombies = 4,
  witches = 5
}

function kids_count(vampire_count, zombie_count, witch_count)
  return {
    vampires = vampire_count,
    zombies = zombie_count,
    witches = witch_count
  }
end

function calculateAvg(kids, houses)
  local candies_per_house = 0
  local total_kids = 0
  for k,v in pairs(kids) do
    total_kids = total_kids + v
    candies_per_house = candies_per_house + candy_distribution[k] * v
  end
  local result = math.floor(candies_per_house * houses / total_kids)
  return result
end

for line in io.lines(arg[1]) do
  local kids, houses = parseLine(line)
  print(
    calculateAvg(kids, houses)
  )
end
