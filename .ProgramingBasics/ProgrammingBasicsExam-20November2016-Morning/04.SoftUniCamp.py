n = int(input())

countCar = 0
countMicrobus = 0
countMiniBus = 0
countBigBus = 0
countTrain = 0
group = 0
groupAll = 0

for i in range(0, n):
    group = int(input())
    groupAll += group

    if group <= 5:
        countCar += group
    elif 5 < group <= 12:
        countMicrobus += group
    elif 12 < group <= 25:
        countMiniBus += group
    elif 25 < group <= 40:
        countBigBus += group
    elif group > 40:
        countTrain += group

print("%.2f%%" % (countCar / groupAll * 100.0))
print("%.2f%%" % (countMicrobus / groupAll * 100.0))
print("%.2f%%" % (countMiniBus / groupAll * 100.0))
print("%.2f%%" % (countBigBus / groupAll * 100.0))
print("%.2f%%" % (countTrain / groupAll * 100.0))
