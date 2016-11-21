x1 = float(input())
y1 = float(input())

x2 = float(input())
y2 = float(input())

area = 2 * (abs(x2 - x1) + abs(y1 - y2))
perimeter = abs(x2 - x1) * abs(y1 - y2)

print(perimeter)
print(area)
