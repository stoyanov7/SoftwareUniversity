function sumNumbers() {
    let firstNumber = document.getElementById('first-number').value;
    let secondNumber = document.getElementById('second-number').value;

    let sum = Number(firstNumber) + Number(secondNumber);

    document.getElementById('result').innerHTML = sum;
}