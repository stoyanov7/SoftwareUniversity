function solve() {
  let degree = document.getElementById('num1').value;
  let type = document.getElementById('type').value.toLowerCase();
  let convertedTemperature = 0;
  let correctType = false;

  convert(degree, type);
  document.getElementById('result').innerHTML = print();

  function convert(degree, type) {
    if (type === 'celsius') {
      correctType = true;
      convertedTemperature = ((degree * 9) / 5) + 32;
    }
    else if (type === 'fahrenheit') {
      correctType = true;
      convertedTemperature = (((degree - 32) * 5) / 9)
    }
  }

  function print() {
    if (correctType) {
      return Math.round(convertedTemperature)
    }
    else {
      return "Error!"
    }
  }
}