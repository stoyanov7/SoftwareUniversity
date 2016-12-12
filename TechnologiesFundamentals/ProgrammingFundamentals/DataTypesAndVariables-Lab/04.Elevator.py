import math

numberOfPeople = int(input())
capacity = int(input())

courses = math.ceil(numberOfPeople / capacity)
print(courses)
