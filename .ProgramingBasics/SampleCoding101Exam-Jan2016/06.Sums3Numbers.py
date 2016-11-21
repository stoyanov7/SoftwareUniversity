num1 = int(input())
num2 = int(input())
num3 = int(input())

minimum = min(num1, num2, num3)
maximum = max(num1, num2, num3)

sum = num1 + num2 + num3
mid = sum - minimum - maximum

if minimum + mid == maximum:
    print("%d + %d = %d" % (minimum, mid, maximum))
else:
    print("No") 
