import math

cubeSide = float(input())
parameter = input()

if parameter == "face":
    face = math.sqrt(math.pow(cubeSide, 2) * 2)
    print("%.2f" % face)

elif parameter == "space":
    space = math.sqrt(math.pow(cubeSide, 2) * 3)
    print("%.2f" % space)

elif parameter == "volume":
    volume = math.pow(cubeSide, 3)
    print("%.2f" % volume)

elif parameter == "area":
    area = math.pow(cubeSide, 2) * 6
    print("%.2f" % area)  
