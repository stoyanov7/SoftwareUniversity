import math

bricks = int(input())
workers = int(input())
bricksPerWorker = int(input())

bricksPerWork = workers * bricksPerWorker
coursesCount = math.ceil(bricks / bricksPerWork)
print(coursesCount)
