file = io.open(arg[1], "r")
size = file:seek("end") 
print(size)
