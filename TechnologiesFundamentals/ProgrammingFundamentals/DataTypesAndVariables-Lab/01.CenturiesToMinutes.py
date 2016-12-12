centuries = int(input())
years = centuries * 100
days = int(years * 365.2422)
hours = days * 24
minutes = hours * 60

print("%d centuries = %d years = %d days = %d hours %d = minutes" %
    (centuries, years, days, hours, minutes))
