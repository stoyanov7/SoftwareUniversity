def printReceiptHeader():
    print("CASH RECEIPT")
    print("------------------------------")

def printReceiptBody():
    print("Charged to____________________")
    print("Received by___________________")

def printReceiptFooter():
    print("------------------------------")
    print("© SoftUni")

if __name__ == '__main__':
    printReceiptHeader()
    printReceiptBody()
    printReceiptFooter()
