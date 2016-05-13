import sys
import os

file_stats = os.stat(sys.argv[1])
print(file_stats.st_size)
