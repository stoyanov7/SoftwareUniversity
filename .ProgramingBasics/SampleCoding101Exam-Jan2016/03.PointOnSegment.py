first = int(input())
second = int(input())
point = int(input())

left = min(first, second)
right = max(first, second)

distanceFromLeft = abs(left - point)
distanceFromRight = abs(right - point)

if left <= point <= right:
    print("in\n%d" % min(distanceFromLeft, distanceFromRight))
else:
    print("out\n%d" % min(distanceFromLeft, distanceFromRight))
