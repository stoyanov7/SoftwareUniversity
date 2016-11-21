x = int(input())
y = int(input())

insideLeft = (x >= 2) and (x <= 12) and (y >= -3) and (y <= 1)
insideRight = (x >= 4) and (x <= 10) and (y >= -5) and (y <= 3)

if insideLeft or insideRight:
    print("in")
else:
    print("out")
