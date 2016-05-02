morsemap = {
    [".-"] = 'A',
    ["-..."] = 'B',
    ["-.-."] = 'C',
    ["-.."] = 'D',
    ["."] = 'E',
    ["..-."] = 'F',
    ["--."] = 'G',
    ["...."] = 'H',
    [".."] = 'I',
    [".---"] = 'J',
    ["-.-"] = 'K',
    [".-.."] = 'L',
    ["--"] = 'M',
    ["-."] = 'N',
    ["---"] = 'O',
    [".--."] = 'P',
    ["--.-"] = 'Q',
    [".-."] = 'R',
    ["..."] = 'S',
    ["-"] = 'T',
    ["..-"] = 'U',
    ["...-"] = 'V',
    [".--"] = 'W',
    ["-..-"] = 'X',
    ["-.--"] = 'Y',
    ["--.."] = 'Z',

    [".----"] = '1',
    ["..---"] = '2',
    ["...--"] = '3',
    ["....-"] = '4',
    ["....."] = '5',
    ["-...."] = '6',
    ["--..."] = '7',
    ["---.."] = '8',
    ["----."] = '9',
    ["-----"] = '0'
}

function decode(codes)
  local decoded = {}
  for code in string.gmatch(codes, "%S+%s*") do
    for c in string.gmatch(code, "%S+") do
      decoded[#decoded + 1] = morsemap[c]
    end
    for c in string.gmatch(code, "%s%s") do
      decoded[#decoded + 1] = " "
    end
  end
  return table.concat(decoded)
end

print(decode("----- ----.  ---.."))

for line in io.lines(arg[1]) do
  io.write(decode(line) .. "\n")
end
