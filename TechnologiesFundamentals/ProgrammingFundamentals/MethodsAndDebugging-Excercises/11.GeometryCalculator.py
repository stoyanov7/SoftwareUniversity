import math

figure = input().lower()
area = 0

if figure == "triangle":
    b = float(input())
    h = float(input())
    area = (b * h) / 2
    print("%.2f" % area)

elif figure == "square":
    a = float(input())
    area = math.pow(a, 2)
    print("%.2f" % area)

elif figure == "rectangle":
    w = float(input())
    h1 = float(input())
    area = w * h1
    print("%.2f" % area)

elif figure == "circle":
    r = float(input())
    area = math.pi * math.pow(r, 2)
    print("%.2f" % area)
