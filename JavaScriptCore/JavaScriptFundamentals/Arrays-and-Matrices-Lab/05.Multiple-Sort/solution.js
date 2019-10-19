function solve() {
  let inputArray = $('#arr').val();
  let array = JSON.parse(inputArray);
  let result = $('#result');

  let ascendingSortedArr = array.sort((a, b) => a - b);
  let ascendindElement = $('<div>');
  ascendindElement.text(ascendingSortedArr.join(', '));
  
  result.append(ascendindElement);

  let alphabeticallySortedArr = array.sort();
  let alphabeticallyElement = $('<div>');
  alphabeticallyElement.text(alphabeticallySortedArr.join(', '));

  result.append(alphabeticallyElement);
}