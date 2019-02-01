function calculator(firstNumber, secondNumber, operator) {
     let sum = 0;

     let service = {
          '+': () => sum = firstNumber + secondNumber,
          '-': () => sum = firstNumber - secondNumber,
          '*': () => sum = firstNumber * secondNumber,
          '/': () => sum = firstNumber / secondNumber,
          '%': () => sum = firstNumber % secondNumber
     };
 
     console.log(service[operator]());
 }