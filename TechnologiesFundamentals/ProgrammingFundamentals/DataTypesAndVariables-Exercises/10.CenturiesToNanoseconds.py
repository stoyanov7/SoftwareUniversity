centuries = int(input())
years = centuries * 100
days = int(years * 365.2422)
hours = days * 24
minutes = hours * 60
seconds = minutes * 60
milliseconds = seconds * 1000
microseconds = milliseconds * 1000
nanoseconds = microseconds * 1000

print("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes ="
      " {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds"
      .format(centuries, years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds)
)
