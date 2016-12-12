distanceInMeters = int(input())
hours = int(input())
minutes = int(input())
seconds = int(input())

hourTime = hours + minutes / 60.0 + seconds / 3600.0
kmSpeed = (distanceInMeters / 1000.0) / hourTime
metersSpeed = kmSpeed / 3.6
milesSpeed = (distanceInMeters / 1609.0) / hourTime

print("%.6f" % metersSpeed)
print("%.6f" % kmSpeed)
print("%.6f" % milesSpeed)
