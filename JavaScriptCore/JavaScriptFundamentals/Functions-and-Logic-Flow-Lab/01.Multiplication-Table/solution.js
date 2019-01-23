function solve() {
  let numberToBeMultiplied = Number(document.getElementById('num1').value);
  let multiplier = Number(document.getElementById('num2').value);
  let divResult = document.getElementById('result');

  findWrongInput(numberToBeMultiplied, multiplier);
  printTable(numberToBeMultiplied, multiplier);

  function findWrongInput(firstNumber, secondNumber) {
    if (firstNumber > secondNumber) {
      divResult.innerHTML = "Try with other numbers."
    }
  }

  function printTable(multiplied, multiplier) {
    for (let i = multiplied; i <= multiplier; i++) {
      let result = multiplier * i;
      let p = document.createElement('p');

      p.innerHTML = `${i} * ${multiplier} = ${result}`;
      divResult.appendChild(p);   
    }
  }
}