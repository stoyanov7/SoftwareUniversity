function solve() {
  let inputArr = JSON.parse(document.getElementById('arr').value);
  let result = document.getElementById('result');
  let p = document.createElement('p');
  let invalidDataParagraph = p.cloneNode();
  invalidDataParagraph.textContent = 'Invalid data';

  let dashElement = p.cloneNode();
  dashElement.textContent = '- - -';
  
  let pattern = /^([A-Z][a-z]* [A-Z][a-z]*) (\+359 \d \d{3} \d{3}|\+359-\d-\d{3}-\d{3}) ([a-z]+@[a-z]+.[a-z0-9]{2,3})$/g;

  inputArr.forEach(element => {
    let match = pattern.exec(element);

    if (match) {
      insertValidElement(`Name: ${match[1]}`);
      insertValidElement(`Phone Number: ${match[2]}`);
      insertValidElement(`Email: ${match[3]}`);
    } 
    else {
      result.appendChild(invalidDataParagraph.cloneNode(true));
    }

    result.appendChild(dashElement.cloneNode(true));
  });

  function insertValidElement(text) {
    let validElement = p.cloneNode();
    validElement.textContent = text;
    result.appendChild(validElement);
  }
}