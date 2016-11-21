bitcoins = int(input())
yuans = float(input())
commission = float(input()) / 100.0

bitcoinsInLeva = bitcoins * 1168.0
yuansToDollars = yuans * 0.15
dollarsToLeva = yuansToDollars * 1.76

levas = bitcoinsInLeva + dollarsToLeva
euros = levas / 1.95
euros -= commission * euros
print(euros)
