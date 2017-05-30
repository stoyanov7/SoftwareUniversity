function calculator(firstNumber, secondNumber, operator) {
    let sum = 0;

    switch (operator) {
        case '+':
            sum = firstNumber + secondNumber;
            break;
        case '-':
            sum = firstNumber - secondNumber;
            break;
        case '*':
            sum = firstNumber * secondNumber;
            break;
        case '/':
            sum = firstNumber / secondNumber;
            break;
        case '%':
            sum = firstNumber % secondNumber;
            break;
    }

    console.log(sum);
}