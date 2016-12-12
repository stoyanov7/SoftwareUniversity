symbol = input()

if (symbol == 'a') or (symbol == 'e') or (symbol == 'i') or (symbol == 'o') or (symbol == 'u'):
    print("vowel")

elif (symbol >= '0') and (symbol <= '9'):
    print("digit")

else:
    print("other")
