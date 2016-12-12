import math

width = float(input())
height = float(input())

perimeter = 2 * (width + height)
area = width * height
diagonal = math.sqrt(width * width + height * height)

print(perimeter)
print(area)
print(diagonal)
