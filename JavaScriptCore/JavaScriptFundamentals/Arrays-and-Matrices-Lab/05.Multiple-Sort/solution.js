function solve() {
  let inputArray = document.getElementById('arr').value
  let array = JSON.parse(inputArray);
  let result = document.getElementById('result');

  let ascendingSortedArr = array.sort((a, b) => a - b);
  let ascendindElement = document.createElement('div');
  ascendindElement.textContent = ascendingSortedArr.join(', ');
  result.appendChild(ascendindElement);

  let alphabeticallySortedArr = array.sort();
  let alphabeticallyElement = document.createElement('div');
  alphabeticallyElement.textContent = ascendingSortedArr.join(', ');
  result.appendChild(alphabeticallyElement);
}