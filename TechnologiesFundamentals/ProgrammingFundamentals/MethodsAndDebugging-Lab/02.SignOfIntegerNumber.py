def printSign(num):
    if num > 0:
        print("The number %d is positive." % num)

    elif num < 0:
        print("The number %d is negative." % num)

    elif num == 0:
        print("The number %d is zero." % num)


number = int(input())
printSign(number)
