function solve() {
  let input = document.getElementById('str').value;
  let resultDiv = document.getElementById('result');

  let numbers = [], words = [];

  input
    .split(' ')
    .filter(x => x != '')
    .forEach(x => {
      if (isNaN(x)) {
        let resultRow = x
          .split('')
          .map(ch => ch.charCodeAt(0))
          .join(' ');

        let p = document.createElement('p');
        p.textContent = resultRow;
        resultDiv.appendChild(p);
      }
      else {
        numbers.push(x);
      }
    });

  let numberToWord = String.fromCharCode(...numbers);
  let p = document.createElement('p');
  p.textContent = numberToWord;
  resultDiv.appendChild(p);
}