function solve() {
  let inputText = document.getElementById('arr').value;
  let inputArr = JSON.parse(inputText);

  let resultDiv = document.getElementById('result');

  for (let i = 0; i < inputArr.length; i++) {
    let product = inputArr[i] * inputArr.length;
    let p = document.createElement('p');

    p.innerHTML = `${i} -> ${product}`;
    resultDiv.appendChild(p);
  }
}